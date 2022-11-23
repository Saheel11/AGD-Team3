using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeInTrigger : MonoBehaviour
{
    public  AudioSource audioMusic;
    public  float secondsToFadeOut = 3f;
    public bool musicFadeIn = false;
    
    public Canvas _canvasStart;


    private void Start()
    {
        audioMusic.volume = 0;    
        _canvasStart.GetComponent<Animator>().SetTrigger("newLevel");

    }

    private void FixedUpdate()
    {
        fadeIn();
    }

    private void fadeIn()
    {
        if (musicFadeIn)
        {
            audioMusic.volume += Time.deltaTime / secondsToFadeOut;    

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        audioMusic.volume -= Time.deltaTime / secondsToFadeOut;    
        // audioMusic.mute = true;   
        musicFadeIn = true;
    }
}
