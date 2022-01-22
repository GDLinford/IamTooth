using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMovePlatform : MonoBehaviour
{
    private Rigidbody rb;
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }
}
