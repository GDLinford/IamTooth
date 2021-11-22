using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//made following this tutorial: https://www.youtube.com/watch?v=1lZrpFUARZo

public class Hook : MonoBehaviour
{
    [SerializeField] float hForce = 25f;

    Grapple mGrapple;
    Rigidbody rigid;
    LineRenderer lineRenderer;

    public void Initialize(Grapple grapple, Transform shootTransform)
    {
        //make sure the grapple hook always shoots straight ahead
        transform.forward = shootTransform.position;
        this.mGrapple = grapple;
        rigid = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        //this lets us shoot the hook forward
        rigid.AddForce(transform.forward * hForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] pos = new Vector3[]
        {
            transform.position,
            mGrapple.transform.position
        };
        lineRenderer.SetPositions(pos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((LayerMask.GetMask("Grabable") & 1 << other.gameObject.layer) > 0)
        {
            rigid.useGravity = false;
            rigid.isKinematic = false;

            mGrapple.StartPull();

            mGrapple.GrappleFired = false;
        }
    }
}
