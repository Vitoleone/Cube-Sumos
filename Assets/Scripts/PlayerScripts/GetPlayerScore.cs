using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerScore : MonoBehaviour
{
    Rigidbody myRb;
    public GetPlayerScore instance;
    public float scale = 1;
    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody>();
        instance = this;
        
    }
   
    public void EatFood()
    {
        scale += 0.15f;
        gameObject.GetComponent<PushScript>().pushPower += 15;
        transform.DOScaleX(scale, 0);
        transform.DOScaleZ(scale, 0);
    }
}
