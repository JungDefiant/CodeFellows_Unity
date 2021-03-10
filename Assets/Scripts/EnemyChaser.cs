using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    Waiting,
    Chasing
}

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceToChase;
    [SerializeField] private float moveSpeed;
    private NavMeshAgent navMeshAgent;
    private TankShooting shooting;
    private TankHealth health;
    private EnemyState state;

    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        shooting = GetComponent<TankShooting>();
        health = GetComponent<TankHealth>();
        navMeshAgent.speed = moveSpeed;
    }

    public void Update()
    {
        // Check the current state
        // Execute method based on state

        switch(state)
        {
            case EnemyState.Waiting:
                DoWaitingState();
                break;
            case EnemyState.Chasing:
                DoChasingState();
                break;
        }
    }

    private void DoWaitingState()
    {
        // If player is within a certain distance, enters chasing state
        // Else does nothing
        if(Vector3.Distance(transform.position, player.position) <= distanceToChase)
        {
            state = EnemyState.Chasing;
        }

        navMeshAgent.destination = transform.position;
    }

    private void DoChasingState()
    {
        // If player is outside of a certain distance, enters waiting state
        // Else chases after player and shoots them
        if (Vector3.Distance(transform.position, player.position) > distanceToChase)
        {
            state = EnemyState.Waiting;
        }
        else
        {
            // Chase the player
            // Aim the turret toward the player
            // Shoot bullet at the player
            shooting.TankAim(player.position);
            shooting.TankShoot();

            if(Vector3.Distance(transform.position, player.position) > distanceToChase / 2)
            {
                navMeshAgent.destination = player.position;
            }
            else navMeshAgent.destination = transform.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            var projectile = collision.gameObject.GetComponent<Projectile>();

            health.TakeDamage(projectile.GetDamage);

            Destroy(projectile.gameObject);
        }
    }
}
