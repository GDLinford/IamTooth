using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearDrop : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private float fallSpeed, spawnTime;
    [SerializeField] private bool respawning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,-1,0) * Time.deltaTime * fallSpeed;

        if (respawning)
        {
            spawnTime -= Time.deltaTime;
        }

        if (spawnTime <= 0)
        {
            transform.position = startPoint.transform.position;
            respawning = false;
            spawnTime = 3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillBox") || other.gameObject.CompareTag("Shelf"))
        {
            //a qucick solution to stop the droplets from glitching on the shelves
            transform.position = new Vector3(1000, 1000, 1000);

            respawning = true;


        }
    }
}
