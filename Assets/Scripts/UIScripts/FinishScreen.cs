using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] GameObject finishScreen;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject sumosDefeatedText;
    [SerializeField] GameObject positionText;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gameManager.instance.isGameOver == true)
        {
            
            finishScreen.SetActive(true);
            scoreText.GetComponent<TextMeshProUGUI>().text = gameManager.instance.score.ToString();
            positionText.GetComponent<TextMeshProUGUI>().text = "#" + (gameManager.GetComponent<PositionScript>().instance.position).ToString();
            sumosDefeatedText.GetComponent<TextMeshProUGUI>().text = gameManager.instance.defeatedSumos.ToString();
        }
        
    }

}
