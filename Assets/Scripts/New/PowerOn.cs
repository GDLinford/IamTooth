using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lights.GetComponent<Animator>().SetBool("PowerOn", true);
            lights.GetComponent<Animator>().Play("Flashing");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lights.GetComponent<Animator>().SetBool("PowerOn", true);
            lights.GetComponent<Animator>().Play("Flashing");
        }
    }
}
