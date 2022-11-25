using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelTrigger : MonoBehaviour
{
    public TimeTravel _timeTravel;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Travel active");
        _timeTravel.canTravel = true;
    }
}
