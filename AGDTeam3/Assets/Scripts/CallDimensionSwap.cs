using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDimensionSwap : MonoBehaviour
{
    [SerializeField] private TimeTravel timeTravelScript;
    [SerializeField] private LayerMask pastLayer;
    [SerializeField] private LayerMask presentLayer;
    [SerializeField] private LayerMask universalMask;
    [SerializeField] private Camera playerCam;

    public void GoToPresent()
    {
        playerCam.cullingMask = universalMask;
        timeTravelScript.world_present.SetActive(true);
        timeTravelScript.world_past.SetActive(false);
        timeTravelScript.canTravel = true;
    }
    public void GoToPast()
    {
        
        playerCam.cullingMask = universalMask;
        timeTravelScript.world_past.SetActive(true);
        timeTravelScript.world_present.SetActive(false);
        timeTravelScript.canTravel = true;
    }

    public void Merge(string destination)
    {
        if(destination == "past")
        {
            playerCam.cullingMask = pastLayer;
        }
        else
        {
            playerCam.cullingMask = presentLayer;
        }



        timeTravelScript.canTravel = false;
        timeTravelScript.world_past.SetActive(true);
        timeTravelScript.world_present.SetActive(true);
    }
}
