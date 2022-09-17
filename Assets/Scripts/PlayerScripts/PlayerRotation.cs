using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float playerAngle;
    private float playerRotateSpeed = 300;
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
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        

        playerAngle += Input.GetAxis("Mouse X") * playerRotateSpeed * Time.deltaTime;
        playerAngle = Mathf.Clamp(playerAngle,-2000,2000);
        player.localRotation = Quaternion.AngleAxis(playerAngle, Vector3.up);
    }
}
