using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager Instance;

    private Vector3 currentCheckpoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
