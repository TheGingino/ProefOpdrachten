using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerClass : CharacterClass
{
    public int damage = 2;
    private UnityEvent takeDamage;

    // Start is called before the first frame update
    private void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
     
    public void Die()
    {
        Debug.Log("Speler is gestorven!");
        CheckPointManager.Instance.RespawnPlayer(this.gameObject);
    }
}
