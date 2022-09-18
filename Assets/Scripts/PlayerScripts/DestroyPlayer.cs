using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyPlayer : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.GetComponent<PositionScript>().instance.position = GameObject.Find("UIController").GetComponent<PlayScreen>().sumos;
            Destroy(other.gameObject);

        }
        if(other.CompareTag("Enemy"))
        {
            if(other.gameObject.GetComponent<GetLastHitted>().instance.lastHitted != null)
            {
                if (other.gameObject.GetComponent<GetLastHitted>().instance.lastHitted.name == "Player")
                {
                    gameManager.AddDefeatedSumo();
                }
            }
            
            Destroy(other.gameObject);
        }
    }
}
