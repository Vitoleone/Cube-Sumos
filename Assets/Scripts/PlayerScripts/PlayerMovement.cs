using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] PlayerRotation playerRotation;
    Rigidbody myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRb.velocity = transform.forward * speed;
    }
}
