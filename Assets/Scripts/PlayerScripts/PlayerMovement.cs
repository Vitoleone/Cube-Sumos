using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] PlayerRotation playerRotation;
    Rigidbody myRb;
    public bool isPushed = false;
    public PlayerMovement instance;
    [SerializeField]GameManager gameManager;

    private void Awake()
    {
        instance = this;
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPushed == false && gameManager.instance.isGameStarted && gameManager.instance.isGamePaused == false && gameManager.instance.isGameOver == false)
        {
          
            myRb.velocity = transform.forward * speed;
        }
        
    }
}
