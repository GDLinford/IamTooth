using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushObj : MonoBehaviour
{
    [SerializeField] private float fMagnitude;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if the object has a rigidbody and is not kinematic then push it
        Rigidbody rb = hit.collider.attachedRigidbody;
        if(rb != null)
        {
            Vector3 forceDir = hit.gameObject.transform.position - transform.position;
            forceDir.y = 0;
            forceDir.Normalize();

            rb.AddForceAtPosition(forceDir * fMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
