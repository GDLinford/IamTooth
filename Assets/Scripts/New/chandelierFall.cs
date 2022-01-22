using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelierFall : MonoBehaviour
{
    [SerializeField] private GameObject chandelierToActivate, ChandelierToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //when the player collides with this start playing the chandelier animation
            chandelierToActivate.SetActive(true);
            ChandelierToDeactivate.SetActive(false);
        }
    }
}
