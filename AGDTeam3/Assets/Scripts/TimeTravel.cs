using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{

    public GameObject world_present;
    public GameObject world_past;
    [SerializeField] private GameObject playerCanvas;

    public bool canTravel;

    private float i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        world_present.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canTravel)
        {
            Debug.Log("pressed");
            i++;
            if (i%2 == 0)  
            {  
                playerCanvas.GetComponent<Animator>().SetTrigger("past");
                Debug.Log("past");
                //world_past.SetActive(false);
                //world_present.SetActive(true);
            }  
            else  
            {  
                playerCanvas.GetComponent<Animator>().SetTrigger("present");
                Debug.Log("present");
                //world_past.SetActive(true);
                //world_present.SetActive(false);
            }  
        }
    }
}
