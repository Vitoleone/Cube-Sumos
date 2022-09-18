using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemyScore : MonoBehaviour
{
    Rigidbody myRb;
    public GetEnemyScore instance;
    public int score = 0;
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
