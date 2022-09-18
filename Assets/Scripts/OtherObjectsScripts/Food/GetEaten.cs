using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEaten : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<GetPlayerScore>().instance.AddScore();
            other.gameObject.GetComponent<GetPlayerScore>().instance.EatFood();
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<GetEnemyScore>().instance.AddScore();
            other.gameObject.GetComponent<GetEnemyScore>().instance.EatFood();
            Destroy(gameObject);
        }
    }
}
