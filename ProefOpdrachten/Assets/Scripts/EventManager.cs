using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public event Action<float> OnPlayerTakeDamage;
    public event Action OnPlayerDie;

    public void PlayerTakeDamage(float damage)
    {
        OnPlayerTakeDamage?.Invoke(damage);
    }

    public void PlayerDie()
    {
        OnPlayerDie?.Invoke();
    }
}
