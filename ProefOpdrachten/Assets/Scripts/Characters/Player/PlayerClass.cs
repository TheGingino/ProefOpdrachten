using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerClass : CharacterClass
{
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

    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
    
}
