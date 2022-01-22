using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class complete : MonoBehaviour
{
    //just a script for the final scene button 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu 1");
    }
}
