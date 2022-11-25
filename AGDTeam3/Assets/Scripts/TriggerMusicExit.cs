using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusicExit : MonoBehaviour
{
    public  AudioSource audiosource_ExitClip;
    [SerializeField] private AudioClip exitClip;

    public  float secondsToFadeOut = 3f;
    public bool musicFadeOut = false;
    public SceneStart _fadeScene;
    
    

    private void FixedUpdate()
    {
        fadeOut();
    }

    private void fadeOut()
    {
        if (musicFadeOut)
        {
            audiosource_ExitClip.volume -= Time.deltaTime / secondsToFadeOut;    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // audioMusic.mute = true;   
        musicFadeOut = true;
        _fadeScene.enabled = false;
        audiosource_ExitClip.PlayOneShot(exitClip); 

    }
}
