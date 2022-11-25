using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Death : MonoBehaviour
{
    public Hook _hook;
    public ReTime _reTime;
    public bool isWaitingForRewind = false;
    public Animator canvasDeath;
    [SerializeField] private CharacterController controller;


    public bool isDead = false;

    //private Transform playerTransform;

    public float verticalSpeed;
    [SerializeField] private float maxSpeedToDie = -20;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        verticalSpeed = controller.velocity.y;
        //Debug.Log(verticalSpeed.ToString());
        DeathFromFall();
        BackToLife();
    }

    private void DeathFromFall()
    {
        if (!isDead && !isWaitingForRewind && verticalSpeed < maxSpeedToDie)
        {
            Dead();
        }
        
        if (isDead && !isWaitingForRewind && verticalSpeed == 0)
        {
            _reTime.StopFeeding();
            isDead = false;
        }
    }
    
    public void Dead()
    {
            Debug.Log("you died");
            isDead = true;
            canvasDeath.SetBool("IsDead", true);
            Invoke("ReadyForRewind",.01f);
    }

    private void ReadyForRewind()
    {
        isWaitingForRewind = true;
        Debug.Log("isWaitingForRewind");


    }

    public void BackToLife()
    {
        if(isWaitingForRewind && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("KeyCodeE");

            _reTime.StartTimeRewind();
            canvasDeath.SetBool("IsDead", false);
            isDead = false;
            _reTime.StartFeeding();
            _hook.enabled = false;
            GetComponent<EmmyFPSController>().gravityOn = false; 
            GetComponent<CharacterController>().enabled = false; 
        }

        if (isWaitingForRewind && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("KeyCodeE releas");

            _reTime.StopTimeRewind();
            _hook.enabled = true;
            GetComponent<EmmyFPSController>().gravityOn = true;
            isWaitingForRewind = false;
            GetComponent<CharacterController>().enabled = true; 

        }
    }
}
