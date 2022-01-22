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
            Manager.SInstance.RespawnPlayer();
            //play the splash sound
            splash.Play();

        }
    }

}
