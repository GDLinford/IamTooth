using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public AudioSource splash;

    //when the player enters the trigger kill them and respawn them
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<CharacterController>().Move(new Vector3(19, 4.6f, -46) - other.transform.position);
            Manager.SInstance.RespawnPlayer();
            splash.Play();

        }
    }

}
