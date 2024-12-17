using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Inspectable]
public class Observer : MonoBehaviour
{
    public UnityEvent<int> OnDamaged;
    private PlayerClass _playerClass;


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player")) OnDamaged?.Invoke(_playerClass.damage);
        Debug.Log("Enemy got Damaged");
    }
}
