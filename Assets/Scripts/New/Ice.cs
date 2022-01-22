using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] private GameObject PlayerTooth, SlipTooth;

    private bool collided;
    [SerializeField] private float cooldown = 3f;

    private AudioSource slip;

    private void Start()
    {
        slip = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //when the player walks on the shampoo puddles play the slip animation
        //dont take damage from this but this begins giving players ideas of what hazards will be around.
        SlipTooth.transform.position = PlayerTooth.transform.position;
        SlipTooth.transform.rotation = PlayerTooth.transform.rotation;
        slip.Play();
        PlayerTooth.SetActive(false);

        SlipTooth.GetComponent<Animator>().Play("Base Layer.Slip", 0,0);
        collided = true;
    }

    private void Update()
    {
        if (collided)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                PlayerTooth.SetActive(true);
                SlipTooth.transform.position = new Vector3(100, 100, 100);
                
                cooldown = 3f;
                this.gameObject.SetActive(false);
            }
        }
    }

}
