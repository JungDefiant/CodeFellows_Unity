using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifetime;
    private Rigidbody rigidbody;
    private float lifetimeCounter;

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

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        // Destroy() is an inefficient method
        // Implement an object pooling system
    }
}
