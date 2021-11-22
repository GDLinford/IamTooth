using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public VideoConrol conrol;
    public GameObject gateClosed;
    public GameObject gateOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        conrol.shouldPlay = true;
        gateClosed.SetActive(false);
        gateOpen.SetActive(true);
    }
}
