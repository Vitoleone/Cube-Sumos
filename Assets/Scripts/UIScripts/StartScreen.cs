using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] GameObject TouchAndPlayText;
    [SerializeField] GameObject CountDownText;
    float countDownNumber = 4;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject PauseButton;
    
    [SerializeField] GameManager gameManager;

    void Start()
    {
        hand.transform.DOMoveX(276, 1f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutFlash); //Tween UI animations for startScreen
        TouchAndPlayText.transform.DOScale(1.2f, 0.5f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
        CountDownText.transform.DOScale(1.2f, 0.5f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }
    private void Update()
    {
        countDownNumber -= Time.deltaTime * 0.9f;
        if (countDownNumber <= 4 && countDownNumber > 0)
        {
            
            CountDownText.GetComponent<TextMeshProUGUI>().text = ((int)countDownNumber).ToString();
        }
        else
        {
            CountDownText.GetComponent<TextMeshProUGUI>().text = "GO";
            if(countDownNumber < -0.5f && CountDownText.GetComponent<TextMeshProUGUI>().text == "GO")
            {
                StartGame();
            }
            
        }
        
    }
    public void StartGame()
    {

        gameManager.instance.isGameStarted = true;
        PauseButton.SetActive(true);
        startScreen.SetActive(false);
        
    }

   
}
