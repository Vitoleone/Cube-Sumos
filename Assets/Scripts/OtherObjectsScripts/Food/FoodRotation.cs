using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotation : MonoBehaviour
{
    Tweener rotateTween;
    void Start()
    {
        rotateTween = transform.DORotate(new Vector3(-transform.rotation.x,360), 1,RotateMode.FastBeyond360)
            .SetLoops(10000, LoopType.Incremental).
            SetEase(Ease.InCirc)
            .OnComplete(delegate
            {
                rotateTween.Kill();
            });
        
    }

  
}
