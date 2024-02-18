using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth;
    public int maxHealth;
    public bool canDamage;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canDamage = true;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Collectables.instance.wineText.text = currentHealth.ToString("D");
    }

    public void TakeDamage(int amount)
    {
        if (canDamage)
        {
            currentHealth -= amount;
            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                ShipEffects shipEffects = GetComponent<ShipEffects>();
                if (shipEffects != null)
                {
                    shipEffects.TakeDamageEffect();
                }
            }
        }
    }

    public void Die()
    {
        UIController.instance.Lose();
        ShipTest.instance.LoseSound();
        //lose panel vb
        Destroy(gameObject);
    }
}
