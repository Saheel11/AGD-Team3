using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public Death _death;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you died");
        _death.Dead();
    }
}
