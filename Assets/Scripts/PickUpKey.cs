using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    public GameObject PowerDoorOpen;
    public GameObject PowerDoorClosed;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PowerDoorClosed.SetActive(false);
            PowerDoorOpen.SetActive(true);
            source.Play(0);
            this.gameObject.SetActive(false);
        }
    }
}
