using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotation : MonoBehaviour
{
    private float rotateTimer;
    private float rotateSpeed = 100f;
    private void Update()
    {
        rotateTimer += Time.deltaTime *rotateSpeed;
        transform.rotation = Quaternion.Euler(Vector3.right * 90 + Vector3.up * rotateTimer);
    }


}
