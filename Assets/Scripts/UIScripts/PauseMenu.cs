using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameManager startScreen;
    [SerializeField] Button PauseButton;
    [SerializeField] GameManager gameManager;
    
    public void OpenPauseMenu()
    {
        PauseScreen.SetActive(true);
        PauseButton.interactable = false;
        gameManager.instance.isGamePaused = true;
        Time.timeScale = 0;
    }
    public void ClosePauseMenu()
    {
        PauseScreen.SetActive(false);
        PauseButton.interactable = true;
        gameManager.instance.isGamePaused = false;
        Time.timeScale = 1;
    }
    public void TryAgain()
    {
        Time.timeScale = 1;
        
        DOTween.KillAll();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        gameManager.instance.isGameStarted = false;
        gameManager.instance.isGamePaused = false;
        
    }
}
