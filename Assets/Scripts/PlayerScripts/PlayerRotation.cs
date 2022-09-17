using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private float playerAngle;
    private float playerRotateSpeed = 500f;
    private void Awake()
    {
        player = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {

            RotateArrow();
        }

    }
    void RotateArrow()
    {
        playerAngle += Input.GetAxis("Mouse X") * playerRotateSpeed * Time.deltaTime;
        playerAngle = Mathf.Clamp(playerAngle, -45, 45);
        player.localRotation = Quaternion.AngleAxis(playerAngle, Vector3.up);
    }
}
