using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private float damage;
    [SerializeField] private GameObject explosion;
    private Rigidbody rigidbody;
    private float lifetimeCounter;

    public float GetDamage { 
        get { return damage; } 
        private set { damage = value; } 
    }

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lifetimeCounter = 0;
    }

    public void FixedUpdate()
    {
        var direction = transform.forward;
        rigidbody.velocity = direction * moveSpeed;

        lifetimeCounter += Time.fixedDeltaTime;

        if (lifetimeCounter >= lifetime)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        var explode = Instantiate(explosion);
        Destroy(explode.gameObject, 1.5f);
    }
}
