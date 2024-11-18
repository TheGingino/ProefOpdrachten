using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterClass : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }

    public virtual void Heal(int healAmount)
    {
        health += healAmount;
    }
}
