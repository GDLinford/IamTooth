using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene("Plot");
    }

    public void ReplayGame()
    {
        //this will let you keep stars
        SceneManager.LoadScene("Plot");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Bathroom");
    }
}
