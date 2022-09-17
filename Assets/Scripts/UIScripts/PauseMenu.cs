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
    [SerializeField] Button PauseButton;
    void Update()
    {
        
    }
    public void OpenPauseMenu()
    {
        PauseScreen.SetActive(true);
        PauseButton.interactable = false;
    }
    public void ClosePauseMenu()
    {
        PauseScreen.SetActive(false);
        PauseButton.interactable = true;
    }
    public void TryAgain()
    {
        DOTween.KillAll();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        
    }
}
