using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    private Slider healthBar;

    public void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = healthManager.GetMaxHealth;
    }

    public void Update()
    {
        // Ideally, you would do something like a delegate; where if the ScriptableObject changes,
        // it would have a list of all the objects it's used on and then it would call an event
        healthBar.value = healthManager.GetHealth;
    }
}
