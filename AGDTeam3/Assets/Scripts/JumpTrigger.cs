using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public Canvas _canvasJump;

    private void Start()
    {
        _canvasJump.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _canvasJump.enabled = true;
    }
}
