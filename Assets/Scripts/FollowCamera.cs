using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Tooth;

    public float followspeed;
    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Tooth.position, followspeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Tooth.rotation, rotateSpeed * Time.deltaTime);
    }
}
