using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeOutTrigger : MonoBehaviour
{
    public  AudioSource audioMusic;
    public  float secondsToFadeOut = 3f;
    public bool musicFadeOut = false;
    public MusicFadeInTrigger _fade;
    
    

    private void FixedUpdate()
    {
        fadeOut();
    }

    private void fadeOut()
    {
        if (musicFadeOut)
        {
            audioMusic.volume -= Time.deltaTime / secondsToFadeOut;    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // audioMusic.mute = true;   
        musicFadeOut = true;
        _fade.enabled = false;
    }
}
