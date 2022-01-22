using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager UInstance;

    public Image RespawnScreen;
    private bool fadingOut, fadingIn;
    //fade speed
    public float SoF = 2f;

    public Slider Hslider;
    public TMP_Text HText, TText, starTexts;

    public GameObject PScreen;

    private void Awake()
    {
        UInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fade to black on death
        if (fadingOut)
        {
            //have to create a new colour as you cant just set the Alpha/a to be 1
            RespawnScreen.color = new Color(0, 0, 0, Mathf.MoveTowards(RespawnScreen.color.a, 1f, SoF * Time.deltaTime));
        }
        //fade back in to game when respawning
        if (fadingIn)
        {
            RespawnScreen.color = new Color(0, 0, 0, Mathf.MoveTowards(RespawnScreen.color.a, 0f, SoF * Time.deltaTime));
        }

        //Pause the game when you press P
        if (Input.GetKeyDown(KeyCode.P))
        {
            PScreenFunctionality();
        }
    }
    //the two fade voids for the respawn screen
    public void FadeOut()
    {
        fadingOut = true;
        fadingIn = false;
    }

    public void FadeIn()
    {
        fadingOut = false;
        fadingIn = true;
    }

    public void HealthUpdate()
    {
        Hslider.maxValue = HeathManager.HInstance.MaxHealth;
        Hslider.value = HeathManager.HInstance.curHealth;
    }

    public void PScreenFunctionality()
    {
        //lock our cursor and pause time when the pause screen is up
        if(PScreen.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            PScreen.SetActive(false);
        }

        else if (PScreen.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            PScreen.SetActive(true);
        }
    }

    public void MainMenu()
    {
        //if we dont put this Time here then the game will always be paused
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TS1()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
