using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField] private LevelLoader _levelLoader;
    private int livesLeft = 3;

    private void Awake()
    {
        Instance = this;
    }

    public void GetHit()
    {
        livesLeft--;
        if (livesLeft <= 0)
        {
            _levelLoader.LoadNextLevel();
        }
    }
}
