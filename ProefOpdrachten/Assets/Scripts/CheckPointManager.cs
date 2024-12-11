using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager Instance; // Singleton for easy access

    private Vector3 currentCheckpoint;

    private void Awake()
    {
        // Singleton patroon om ervoor te zorgen dat er maar één GameManager is.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentCheckpoint(Vector3 checkpointPosition)
    {
        currentCheckpoint = checkpointPosition;
        Debug.Log("Huidig checkpoint bijgewerkt naar: " + checkpointPosition);
    }

    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = currentCheckpoint;
    }
}
