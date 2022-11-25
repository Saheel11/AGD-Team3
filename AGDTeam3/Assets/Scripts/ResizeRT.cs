using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeRT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resize(this.GetComponent<Camera>().targetTexture, Screen.width, Screen.height);
    }

    void Resize(RenderTexture renderTexture, int width, int height) 
    {
        if (renderTexture) 
        {
            renderTexture.Release();
            renderTexture.width = width;
            renderTexture.height = height; 
        }
    }
}
