using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{

    [SerializeField] private GameObject world_present;
    [SerializeField] private GameObject world_past;
    private float i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        world_past.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("pressed");
            i++;
            if (i%2 == 0)  
            {  
                Debug.Log("past");
                world_past.SetActive(false);
                world_present.SetActive(true);
            }  
            else  
            {  
                Debug.Log("present");
                world_past.SetActive(true);
                world_present.SetActive(false);
            }  
        }
    }
}
