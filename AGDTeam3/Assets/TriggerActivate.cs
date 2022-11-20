using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{
    public Death _death;
    public TimeTravel _timeTravel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TimeActivation")
        {
            Debug.Log("Travel active");
            _timeTravel.canTravel = true;
        }
        
        if (other.gameObject.tag == "danger")
        {
            Debug.Log("danger");
            _death.Dead();
        }
    }
}
