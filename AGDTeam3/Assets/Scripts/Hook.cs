using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    [SerializeField] private Camera playerCam;
    [SerializeField] private CharacterController controller;
    private Vector3 hookShotPos;
    [SerializeField] private bool traveling;

    public GameObject debugCube;
    public LineRenderer lineRenderer;


    void Update()
    {

        if(Vector3.Distance(hookShotPos, transform.position) > 2f && traveling == true)
        {
            lineRenderer.enabled = true;
            HookShotMove();
            
        }
        else
        {
            lineRenderer.enabled = false;
            traveling = false;
        }
        
        if(Input.GetKeyDown(KeyCode.G))
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
    }

    void ShootHook()
    {
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit))
        {
            
            if(hit.transform.tag == "hookable")
            {
                traveling = true;
                hookShotPos = hit.point;
            }
            
            
        }
    }
    void HookShotMove()
    {

        this.GetComponent<EmmyFPSController>().gravityOn = false;
        

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hookShotPos);

        float maxSpeed = 30f;
        float minSpeed = 10f;
        float hookShotSpeed = Mathf.Clamp(Vector3.Distance(hookShotPos, transform.position), minSpeed, maxSpeed);

        Vector3 hookshotDir = (hookShotPos - transform.position).normalized;
        controller.Move(hookshotDir * Time.deltaTime * hookShotSpeed * 2f);


    }
}
