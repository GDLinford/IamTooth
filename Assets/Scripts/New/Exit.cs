using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //when we enter the exit trigger go to the next scene in the build index
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Exit here");
        }
    }
}
