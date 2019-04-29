﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;
    
    public string[] levels;

    public int CurrentLevel { get; private set; }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(gameObject);
        }

        CurrentLevel = 0;
    }

    public bool HasNextLevel()
    {
        CurrentLevel++;

        Debug.Log(CurrentLevel);
        Debug.Log(levels.Length);
        return CurrentLevel < levels.Length;
    }

    public string GetNextLevelName()
    {
        return levels[CurrentLevel];
    }
}
