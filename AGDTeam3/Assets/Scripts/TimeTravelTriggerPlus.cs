using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelTriggerPlus : MonoBehaviour
{
    public Canvas _canvasTravel;
    public TimeTravel _timeTravel;

    private void Start()
    {
        _canvasTravel.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Travel active");
        _timeTravel.canTravel = true;
        _canvasTravel.enabled = true;
    }
}
