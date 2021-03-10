using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Manager", menuName = "Managers/Health Manager")]
public class HealthManager : ScriptableObject
{
    [SerializeField] private float maximumHealth;
    [SerializeField] private float currentHealth;

    public float GetHealth {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }

    public float GetMaxHealth
    {
        get { return maximumHealth; }
        private set { maximumHealth = value; }
    }

    public void ResetHealth()
    {
        currentHealth = maximumHealth;
    }

    public float ModifyHealth(float value)
    {
        currentHealth += value;

        if(currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        else if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        return currentHealth;
    }
}
