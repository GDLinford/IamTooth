using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene("Bathroom");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
