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
            //moveTween = transform.DOMove(new Vector3(Player.transform.position.x,transform.position.y,Player.transform.position.z-5f), 0, false);//camera's position should be player's backside, for this we can do some adjustment on z axis.
            transform.position = new Vector3(Player.transform.position.x, 8.689468f, Player.transform.position.z - 5f);
        }
        
    }
}
