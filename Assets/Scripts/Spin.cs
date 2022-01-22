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
        transform.Rotate(0, speed, 0);

        if(collided == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = 0.3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = true;
            Source.Play();
            Manager.SInstance.StarGot();
            
        }
    }
}
