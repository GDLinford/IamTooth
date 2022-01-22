using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerActivate : MonoBehaviour
{
    //this is just a very generic class set up so if I need one thing activated onTrigger collisions
    //I can do it all here

    public GameObject objToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objToActivate.SetActive(true);
        }

        if (other.gameObject.CompareTag("Water"))
        {
            objToActivate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
