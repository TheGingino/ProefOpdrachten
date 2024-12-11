using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Vector3 respawnPosition; // De positie waar de speler opnieuw spawnt.
    private bool isActivated = false;

    private void Start()
    {
        // Stel de respawnpositie in op de positie van het checkpoint.
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        isActivated = true;
        Debug.Log("Checkpoint geactiveerd: " + transform.position);

        // Informeer de GameManager over dit checkpoint.
        CheckPointManager.Instance.SetCurrentCheckpoint(respawnPosition);
    }
}
