using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform startPoint, endpoint;
    [SerializeField] private float TravelTime;
    [SerializeField] private bool goingForward, goingBack;

    private Rigidbody rb;

    private Vector3 curPos;

    CharacterController characterController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        goingForward = true;
    }

    private void FixedUpdate()
    {
        //smoothly move the gameobject from one point to the next
        curPos = Vector3.Lerp(startPoint.position, endpoint.position, Mathf.Cos(Time.time / TravelTime * Mathf.PI * 2) * -.5f + .5f);
        rb.MovePosition(curPos);
    }

    private void Update()
    {
        //when we get to the end of one of the points rotate the model and go the other way

        if((Vector3.Distance(transform.position, endpoint.position) <= 0.01) && goingForward && gameObject.CompareTag("Duck"))
        { 
            transform.Rotate(0, 180, 0);
            goingForward = false;
            goingBack = true;
        }

        if((Vector3.Distance(transform.position, startPoint.position) <= 0.01) && goingBack && gameObject.CompareTag("Duck"))
        {
            transform.Rotate(0, 180, 0);
            goingBack = false;
            goingForward = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterController = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //make the player object a child of the platform so its stays on
        if (other.gameObject.CompareTag("Player"))
        {
            characterController.Move(rb.velocity * Time.deltaTime);
            characterController.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //unparent the child
        if (other.gameObject.CompareTag("Player"))
        {
            characterController.transform.parent = null;
        }
    }
}
