using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{

    public Light2D flashLight;
    public float intensity;

    
    // Start is called before the first frame update
    void start()
    {
        
    }
    public void switchLight()
    {
        FindObjectOfType<AudioManager>().Play("flashlightSound");

        if(flashLight.intensity == 0.0f)
        {
            flashLight.intensity = 1.5f;
        }
        else
        {
            flashLight.intensity = 0.0f;
        }
    }
    
}
