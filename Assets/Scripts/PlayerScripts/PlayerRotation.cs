using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float playerAngle;
    private float playerRotateSpeed = 1;
    public Vector3 mousepos;
    public Vector3 direction;
    public Quaternion lookRotation;
    private void Awake()
    {
        player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {

            RotatePlayer();
            
        }

    }
    void RotatePlayer()
    {
        var lookAtPos = Input.mousePosition;
        lookAtPos.z = Camera.main.transform.position.y - transform.position.y;
        lookAtPos = Camera.main.ScreenToWorldPoint(lookAtPos);
        var lookPos = lookAtPos - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos);
        lookRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, lookRot.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 10f);
    }
}
