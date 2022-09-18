using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLastHitted : MonoBehaviour
{
    public GameObject lastHitted;//Last hitted object
    public GetLastHitted instance;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();//getting gameManager in hierarcy
        instance = this;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != null)
        {
            lastHitted = collision.gameObject;//lastHitted object declaration
        }
    }
}
