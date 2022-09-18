using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayScreen : MonoBehaviour
{
    //This is for screen for in playtime.
    
    [SerializeField] GameObject Player;
    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject playScreen;
    [SerializeField] GameObject finishScreen;
    [SerializeField] GameObject CountdownNumberText;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject SumosLeftText;
    [SerializeField] GameObject GameManager;
    


    public int sumos;
    int score;
    float countdownTimer = 126;

   

    
    void Update()
    {
        countdownTimer -= Time.deltaTime;//Timers value decrease every second

        if(StartScreen.activeInHierarchy == false && Player.gameObject != null)
        {
            ScoreText.GetComponent<TextMeshProUGUI>().text =  GameManager.GetComponent<GameManager>().instance.score.ToString();
            sumos = GameObject.FindGameObjectsWithTag("Enemy").Length+1;//Enemies + 1(player)
            if(playScreen.activeInHierarchy == false)
            {
                playScreen.SetActive(true);
            }
            SumosLeftText.GetComponent<TextMeshProUGUI>().text = sumos.ToString();
            Count(countdownTimer);
            
        }
        if(CountdownNumberText.GetComponent<TextMeshProUGUI>().text == "00:00" || sumos == 1 || Player.gameObject == null)
        {
            GameManager.GetComponent<GameManager>().instance.isGameOver = true;
            playScreen.SetActive(false);
            finishScreen.SetActive(true);
        }
        
    }
    void Count(float timeToDisplay)
    {
        float sec = Mathf.FloorToInt(timeToDisplay % 60);
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        CountdownNumberText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", min, sec);

    }
}
