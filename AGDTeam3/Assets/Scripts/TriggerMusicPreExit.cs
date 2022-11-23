using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusicPreExit : MonoBehaviour
{
    public  AudioSource audiosource_mainSong;

    public  float secondsToFadeOut = 3f;
    public bool musicFadeOut = false;
    
    

    private void FixedUpdate()
    {
        fadeOut();
    }

    private void fadeOut()
    {
        if (musicFadeOut)
        {
            audiosource_mainSong.volume -= Time.deltaTime / secondsToFadeOut;    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        musicFadeOut = true;
    }
}
