using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToysAway : MonoBehaviour
{
    //the toy care the player pushes
    [SerializeField] private GameObject toyToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ToyBox"))
        {
            //when each of the toys get to the toybox actiavte them in the box 
            toyToActivate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
