using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public bool isGameStarted = false;
    public bool isGamePaused = false;
    public bool isGameOver = false;
    public int score;
    public int defeatedSumos;
    
    private void Awake()
    {
        instance = this;
    }
    public void AddScore()
    {
        score += 100;
    }
    public void AddDefeatedSumo()
    {
        defeatedSumos++;
        score += 1000;
    }


}
