using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterClass : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public UnityEvent<float> OnTakeDamage;
    public UnityEvent OnDie;

    public virtual void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        OnTakeDamage.Invoke(damage);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDie.Invoke();
        }    
    }

    public virtual void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }
}
