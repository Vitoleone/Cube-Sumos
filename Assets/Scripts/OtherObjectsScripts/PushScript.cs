using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushScript : MonoBehaviour
{
    Rigidbody myRb;
    public float pushPower;
    public GameObject lastHitted;
    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Enemy"))
        {

            enemyRigidbody.AddRelativeForce(awayFromPlayer * pushPower*Time.deltaTime, ForceMode.Impulse);
            collision.gameObject.GetComponent<EnemyMovement>().instance.isPushed = true;
            StartCoroutine(WaitForSeconds(collision.gameObject));
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            enemyRigidbody.AddRelativeForce(awayFromPlayer * pushPower * Time.deltaTime, ForceMode.Impulse);
            collision.gameObject.GetComponent<PlayerMovement>().instance.isPushed = true;
            StartCoroutine(WaitForSeconds(collision.gameObject));     
        }
    }
    
       
    IEnumerator WaitForSeconds(GameObject collision)
    {
        
        yield return new WaitForSeconds(0.5f);
        
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerMovement>().instance.isPushed = false;
                lastHitted = collision.gameObject;

            }
            else if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyMovement>().instance.isPushed = false;
                lastHitted = collision.gameObject;
            }
        }
       
        
        
    }
 }
   

