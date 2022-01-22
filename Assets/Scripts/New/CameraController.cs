using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    //follow the player
    [SerializeField] private Vector3 offset;
    [SerializeField] private Quaternion rotOffset1, rotOffset2, rotOffset3, rotOffset4;

    [SerializeField] private float CamSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;

        //hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, CamSpeed * Time.deltaTime);

        if(transform.position.y < 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }


        //these change which direction the camera is facing
        if (Input.GetButtonDown("cam1Activate"))
        {
            transform.rotation = rotOffset1;
            offset = new Vector3(0, 2, -3);
        }

        if (Input.GetButtonDown("cam2Activate"))
        {
            transform.rotation = rotOffset2;
            offset = new Vector3(-3, 2, 0);
        }

        if (Input.GetButtonDown("cam3Activate"))
        {
            
            transform.rotation = rotOffset3;
            offset = new Vector3(3, 2, 0);
        }

        if (Input.GetButtonDown("cam4Activate"))
        {
            transform.rotation = (rotOffset4);
            offset = new Vector3(0, 2, 3);
        }
    }
}
