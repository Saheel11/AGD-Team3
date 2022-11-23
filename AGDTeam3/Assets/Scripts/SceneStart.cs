using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public  AudioSource audioMusic;
    public  float secondsToFadeOut = 3f;
    
    public Canvas _canvasStart;


    private void Start()
    {
        audioMusic.volume = 0;    
        _canvasStart.GetComponent<Animator>().SetTrigger("newLevel");

        fadeIn();
    }

    private void FixedUpdate()
    {
        fadeIn();
    }

    private void fadeIn()
    {
        audioMusic.volume += Time.deltaTime / secondsToFadeOut;

    }
}
