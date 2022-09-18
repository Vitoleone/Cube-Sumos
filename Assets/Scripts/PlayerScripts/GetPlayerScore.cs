using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerScore : MonoBehaviour
{
    Rigidbody myRb;
    public GetPlayerScore instance;
    public int score;
    public float scale = 1;
    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody>();
        instance = this;
        
    }
    public void AddScore()
    {
        score += 100;
    }
    public void EatFood()
    {
        scale += 0.15f;
        myRb.mass += 10;
        transform.DOScaleX(scale, 0);
        transform.DOScaleZ(scale, 0);
    }
}
