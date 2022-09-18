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
    [SerializeField] GameObject gameManager;


    private void Update()
    {
        if(gameManager.GetComponent<GameManager>().instance.isGameOver == true)
        {
            
            finishScreen.SetActive(true);
            scoreText.GetComponent<TextMeshProUGUI>().text = gameManager.GetComponent<GameManager>().instance.score.ToString();
            positionText.GetComponent<TextMeshProUGUI>().text = "#" + (gameManager.GetComponent<PositionScript>().instance.position+1).ToString();
        }
        
    }

}
