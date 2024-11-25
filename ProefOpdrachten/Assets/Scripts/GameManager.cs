using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public bool hasWon;
    // Start is called before the first frame update
    public static GameManager instane()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
