using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    //used for a singleton
    public static Manager SInstance;

    [HideInInspector] public float TimerNum;

    //how long before dying/respawning after death
    [SerializeField] private float RespawnDelay;

    [HideInInspector] public bool curRespawning;

    private PlayerController player;

    public Vector3 respawnPoint;

    public int curStars;

    void Awake()
    {
        SInstance = this;
        curStars = PlayerPrefs.GetInt("Stars");
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        //our respawn point for when we start the game
        respawnPoint = player.transform.position + Vector3.up;

        //reference to our UI manager for out star count
        UIManager.UInstance.starTexts.text = curStars.ToString();
    }

    public void RespawnPlayer()
    {
        //this will be called when the player dies
        //if we are not currently respawning then respawn
        if (!curRespawning)
        {
            curRespawning = true;

            StartCoroutine(respawn());
        }
    }

    private void Update()
    {
        TimerNum += Time.deltaTime;
        //"f2" put the text to two decimal places so it works like this 10.21 as opposed to 10.21464343
        UIManager.UInstance.TText.text = TimerNum.ToString("f2");
    }

    public IEnumerator respawn()
    {
        //by setting it too false we dont need to worry about using the characterCOntroller component to move
        player.gameObject.SetActive(false);

        //fade screen to black and wait for the respawn timer
        UIManager.UInstance.FadeOut();
        yield return new WaitForSeconds(RespawnDelay);

        //move the player to the current respawn point then set it active again
        player.transform.position = respawnPoint;
        player.gameObject.SetActive(true);

        curRespawning = false;
        UIManager.UInstance.FadeIn();

        //set our health back to full
        HeathManager.HInstance.HealthSet();
    }

    public void StarGot()
    {
        //increase and display our current number of stars
        curStars++;
        UIManager.UInstance.starTexts.text = curStars.ToString();

        //save our value of stars between levels
        PlayerPrefs.SetInt("Stars", curStars);
    }

}
