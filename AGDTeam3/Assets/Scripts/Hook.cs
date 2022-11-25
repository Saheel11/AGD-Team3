using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Hook : MonoBehaviour
{

    [SerializeField] private Camera playerCam;
    [SerializeField] private CharacterController controller;
    public Vector3 hookShotPos;
    private bool traveling;
    private bool casting;
    [SerializeField] private float castingSpeed;

    [Header("Blur hook")]
    [SerializeField] private Animator blurHookAnimator;
    [SerializeField] private float distanceHookPlayer = 2f;

    [Header("Hook audio")] 
    [SerializeField] AudioSource _audioSourceDrag;
    [SerializeField] AudioSource _audioSourceHit;
    [SerializeField] private AudioClip sfxHookPull;
    [SerializeField] private AudioClip sfxHookHit;

    

    public float hookRange;

    public GameObject debugCube;
    public LineRenderer lineRenderer;
    
    private float timer;

    [SerializeField] private GameObject activeCrosshair;
    [SerializeField] private GameObject idleCrosshair;

    [SerializeField] private Transform hookStart;


    private void Awake()
    {
    }

    void Update()
    {

        if(Vector3.Distance(hookShotPos, transform.position) > 2f && traveling == true)
        {
            lineRenderer.enabled = true;
            HookShotMove();
            
        }
        else if(casting)
        {
            lineRenderer.enabled = true;
            HookShotCast();    
        }
        else
        {
            lineRenderer.enabled = false;
            traveling = false;
        }
        
        
        if(Input.GetMouseButtonDown(0))
        {
            ShootHook();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            traveling = false;
            this.GetComponent<EmmyFPSController>().gravityOn = true;
        }
        debugCube.transform.position = hookShotPos;

        if(traveling == false)
        {
            this.GetComponent<EmmyFPSController>().gravityOn = true;
        }

        //crosshair update
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, hookRange))
        {
            if(hit.transform.tag == "hookable")
            {
                activeCrosshair.SetActive(true);
                idleCrosshair.SetActive(false);
            }
            else
            {
                activeCrosshair.SetActive(false);
                idleCrosshair.SetActive(true);
            }
        }
        else
        {
            activeCrosshair.SetActive(false);
            idleCrosshair.SetActive(true);
        }
    }

    void ShootHook()
    {
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, hookRange))
        {
            
            if(hit.transform.tag == "hookable")
            {
                timer = 0f;
                lineRenderer.SetPosition(1, hookStart.position);
                //traveling = true;
                casting = true;
                hookShotPos = hit.point;
                
                //Activate blur postprocess
                blurHookAnimator.SetBool("hookBlur", true);
                
                _audioSourceDrag.PlayOneShot(sfxHookPull); 
                _audioSourceHit.PlayOneShot(sfxHookHit); 
            }
        }
    }
    void HookShotCast()
    {
        
        traveling = false;
        timer += Time.deltaTime * castingSpeed;


        lineRenderer.SetPosition(0, hookStart.position);
        lineRenderer.SetPosition(1, Vector3.Lerp(hookStart.position, hookShotPos, Mathf.Clamp(timer, 0, 1f)));

        if(timer > 1f)
        {
            timer = 0f;
            casting = false;
            traveling = true;
        }
    }


    void HookShotMove()
    {

        this.GetComponent<EmmyFPSController>().gravityOn = false;
        
        lineRenderer.SetPosition(0, hookStart.position);
        lineRenderer.SetPosition(1, hookShotPos);

        float maxSpeed = 30f;
        float minSpeed = 10f;
        float hookShotSpeed = Mathf.Clamp(Vector3.Distance(hookShotPos, transform.position), minSpeed, maxSpeed);

        Vector3 hookshotDir = (hookShotPos - transform.position).normalized;
        controller.Move(hookshotDir * Time.deltaTime * hookShotSpeed * 2f);

        
        if (Vector3.Distance(GetComponent<Transform>().position, hookShotPos) <= distanceHookPlayer)
        {
            Debug.Log("HookEnded");
            blurHookAnimator.SetBool("hookBlur", false);
            
            _audioSourceDrag.Stop();
        }

    }
}
