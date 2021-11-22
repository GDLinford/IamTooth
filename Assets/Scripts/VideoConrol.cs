using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoConrol : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    public bool shouldPlay;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldPlay)
            videoPlayer.Play();
        else
            videoPlayer.Pause();
    }
}
