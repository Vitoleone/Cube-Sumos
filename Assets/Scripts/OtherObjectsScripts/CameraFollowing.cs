using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public Tweener moveTween;
    [SerializeField] GameManager gameManager;
    
    

    void Update()
    {
        
        if(Player != null && gameManager.instance.isGameStarted)
        {
            transform.position = new Vector3(Player.transform.position.x+7, 12, Player.transform.position.z - 5f);//camera's position should be player's backside, for this we can do some adjustment on z and x axis.
        }
        
    }
}
