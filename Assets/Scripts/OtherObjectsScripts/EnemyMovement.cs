using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<GameObject> allPlayers;
    [SerializeField] float moveSpeed = 225f;
    GameObject[] allplayersArray;
    Rigidbody myRb;
    Vector3 moveDirection;
    Tweener myTweener;
    private void Awake()
    {
        allPlayers = new List<GameObject>();
        allplayersArray = GameObject.FindGameObjectsWithTag("Player");
        myRb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 225f;
    }
    private void Start()
    {
        ArrayToList(allplayersArray);
    }
    private void FixedUpdate()
    {
        
        CheckDestroyedGameObjects(allPlayers);
        moveDirection = GetDirectionToNearestEnemy(GetNearestEnemy(allPlayers));
        myRb.velocity = moveDirection * moveSpeed * Time.deltaTime;
        myTweener =  myRb.DOLookAt(moveDirection, 0,AxisConstraint.Y).OnComplete(delegate
        {
            myTweener.Kill();
        });

    }
    void ArrayToList(GameObject[] playersArray)
    {
        for (int i = 0; i < playersArray.Length; i++)
        {
            allPlayers.Add(playersArray[i]);
        }
    }
    void CheckDestroyedGameObjects(List<GameObject> players)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if(players[i] == null || players[i].name == gameObject.name)
            {
                players.RemoveAt(i);
            }
        }
    }
    Transform GetNearestEnemy(List<GameObject> players)
    {
        Transform nearestEnemy;
        List<float> distances = new List<float>();
        
        for (int i = 0; i < players.Count; i++ )
        {
            distances.Add(Vector3.Distance(gameObject.transform.position, players[i].transform.position));
        }
         int index = distances.FindIndex(distance => distances.Min() == distance);
        nearestEnemy = players[index].transform;
        return nearestEnemy;
    }
    Vector3 GetDirectionToNearestEnemy(Transform nearestEnemy)
    {
        return new Vector3(
            nearestEnemy.position.x - transform.position.x,
            transform.position.y,
            nearestEnemy.position.z - transform.position.z 
            ).normalized;
    }
}
