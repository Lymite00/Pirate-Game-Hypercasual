using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy health"+currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
