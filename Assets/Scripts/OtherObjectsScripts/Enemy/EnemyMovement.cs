using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<GameObject> allObjects;
    [SerializeField] float moveSpeed = 6.5f;
    GameObject[] allplayersArray;
    GameObject[] allFoodsArray;
    Rigidbody myRb;
    Vector3 moveDirection;
    Tweener myTweener;
    [SerializeField] GameManager gameManager;

    public EnemyMovement instance;
    public bool isPushed = false;

    private void Awake()
    {
        instance = this;
        allObjects = new List<GameObject>();
        allplayersArray = GameObject.FindGameObjectsWithTag("Enemy");
        allFoodsArray = GameObject.FindGameObjectsWithTag("Food");
        allplayersArray[allplayersArray.Length-1] = GameObject.FindGameObjectWithTag("Player"); 
        myRb = gameObject.GetComponent<Rigidbody>();
        
    }
    private void Start()
    {
        ArrayToList(allplayersArray,allFoodsArray);
    }
    private void FixedUpdate()
    {
        CheckDestroyedGameObjects(allObjects);
        if (gameManager.instance.isGameStarted && gameManager.instance.isGamePaused == false && gameManager.instance.isGameOver == false)
        {
            if (isPushed == false)
            {
               
                
                moveDirection = GetDirectionToNearestEnemy(GetNearestEnemy(allObjects));
                myRb.velocity = moveDirection * moveSpeed;
                myTweener = myRb.DOLookAt(moveDirection, 0, AxisConstraint.Y).OnComplete(delegate
                {
                    myTweener.Kill();
                });
            }
            
        }
       


    }
    void ArrayToList(GameObject[] playersArray, GameObject[] foods)
    {
        for (int i = 0; i < playersArray.Length; i++)
        {
            allObjects.Add(playersArray[i]);
        }
        for (int i = 0; i < foods.Length; i++)
        {
            allObjects.Add(foods[i]);
        }
    }
    void CheckDestroyedGameObjects(List<GameObject> Objects)
    {
        for(int i = 0; i < Objects.Count; i++)
        {
            if(Objects[i] == null || Objects[i].name == gameObject.name)
            {
                Objects.RemoveAt(i);
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
