using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : CharacterClass
{
    [SerializeField] private int damage = 2;
    [SerializeField] private Action takeDamage;

    void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
    }


    public float damageAmount = 5f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time > lastAttackTime + attackCooldown)
        {
            PlayerClass playerHealth = other.GetComponent<PlayerClass>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
    
}
