using System.Collections;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField] private HealthManager health;

    private void Start()
    {
        health.ResetHealth();
    }

    public void TakeDamage(float damage)
    {
        health.ModifyHealth(-damage);
    }

}