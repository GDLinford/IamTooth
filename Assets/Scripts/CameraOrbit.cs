using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float lookSensitivity;

    public float minXLook;
    public float maxXLook;
 
    public Transform camAnchor;
    public float curXRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void LateUpdate()
    {
        //get the mouse x and y inputs
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //rotate horizontally
        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        //look up and down
        curXRot -= y * lookSensitivity;

        //restrict how far curXrot can go this should put it between minXLook and maxXlook
        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        //we need to temporarily store camAnchor angle in a vector 3
        Vector3 clampedAngle = camAnchor.eulerAngles;
        //apply the current X rotation to clampedAngle on the x axis
        clampedAngle.x = curXRot;

        //now assign clamp angle back to the camera
        camAnchor.eulerAngles = clampedAngle;
    }
}
