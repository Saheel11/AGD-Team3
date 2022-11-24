using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
   [SerializeField] float period = 2f;
    Vector3 startingScale;
    [SerializeField] Vector3 scaleVector;
    float scaleFactor;
    
    private void Start() 
    {
        startingScale=transform.localScale;
    }
 
    private void Update() 
    {
        if (period <= Mathf.Epsilon) {return;}     // To avoid number 0 or close to 0. Epsilon is a tiny number

        float cycles = Time.time / period;  // Continuous rolling over time 
     
        const float tau = Mathf.PI * 2;     // Constant value of 6.28
        float rawSineWave = Mathf.Sin(cycles * tau);  // Values from -1 to 1
    
        scaleFactor = (rawSineWave + 1f) / 2f;  // Recalculated values from  0 to 1

        Vector3 offsetPosition = scaleVector * scaleFactor;
        transform.localScale = startingScale + offsetPosition;
    }
}

