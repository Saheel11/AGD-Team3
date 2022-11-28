using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeTravel : MonoBehaviour
{
    public AudioSource pastMusic;
    public AudioSource presentMusic;
    [SerializeField] AudioSource timeTravelSFX;
    [SerializeField] private AudioClip timeTravel;


    public PostProcessLayer _layer;
    
    public GameObject world_present;
    public GameObject world_past;
    [SerializeField] private GameObject playerCanvas;

    //Skybox
    [SerializeField] private Material SkyPresent;
    [SerializeField] private Material SkyPast;
    [SerializeField] private float fogPresent = 0.03f;
    [SerializeField] private float fogPast = 0.01f;
    
    
    public bool canTravel;

    private float i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //world_present.SetActive(false);
        world_present.SetActive(true);
        world_past.SetActive(false);
        canTravel = false;
        
        presentMusic.mute = false;
        pastMusic.mute = true;
        
        RenderSettings.skybox=SkyPresent;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && canTravel)
        {
            i++;
            if (i%2 == 0)  
            {  
                playerCanvas.GetComponent<Animator>().SetTrigger("present");
                Debug.Log("present");
                
                _layer.volumeLayer = LayerMask.GetMask("PP_Present");
                
                RenderSettings.skybox=SkyPresent;
                RenderSettings.fogDensity = fogPresent;
                timeTravelSFX.PlayOneShot(timeTravel);

                presentMusic.mute = false;
                pastMusic.mute = true;
                



                //world_past.SetActive(false);
                //world_present.SetActive(true);
            }  
            else  
            {  
                playerCanvas.GetComponent<Animator>().SetTrigger("past");
                Debug.Log("past");
                
                _layer.volumeLayer = LayerMask.GetMask("PP_Past");
                RenderSettings.fogDensity = fogPast;

                timeTravelSFX.PlayOneShot(timeTravel);
                presentMusic.mute = true;
                pastMusic.mute = false;
                
                RenderSettings.skybox=SkyPast;

                //world_past.SetActive(true);
                //world_present.SetActive(false);
            }  
        }
    }
}
