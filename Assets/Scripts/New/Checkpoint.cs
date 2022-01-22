using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private GameObject InactivePoint, ActivePoint, CheckPointParticle;
    AudioSource activate;

    private void Start()
    {
        activate = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Manager.SInstance.respawnPoint != ActivePoint.transform.position)
            {
                Manager.SInstance.respawnPoint = ActivePoint.transform.position;
                CheckPointParticle.SetActive(true);
                activate.Play();
            }
            //go through all checkpoints and "reset" them
            Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
            foreach(Checkpoint cp in checkpoints)
            {
                cp.ActivePoint.SetActive(false);
                cp.InactivePoint.SetActive(true);
            }

            //this will only activate the one we walk through deactivating the previous ones.
            ActivePoint.SetActive(true);
            InactivePoint.SetActive(false);

        }
    }
}
