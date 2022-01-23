using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public AudioSource Source;
    public float speed, timer;
    private bool collided;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the star
        transform.Rotate(0, speed, 0);

        //if the player has collided with the star then start counting down the timer
        if(collided == true)
        {
            timer -= Time.deltaTime;
        }
        //destroy this gameobject when that timer is 0
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = 0.3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //only the player can collide with this
        if (other.gameObject.CompareTag("Player"))
        {
            collided = true;
            Source.Play();
            Manager.SInstance.StarGot();
            
        }
    }
}
