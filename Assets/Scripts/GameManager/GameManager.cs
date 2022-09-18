using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public bool isGameStarted = false;
    public bool isGamePaused = false;
    private void Awake()
    {
        instance = this;
    }
   

}
