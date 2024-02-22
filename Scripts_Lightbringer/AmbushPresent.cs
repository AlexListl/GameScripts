using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushPresent : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player")
        {
             FindObjectOfType<TimeTravelEvent>().enabled = false;
             FindObjectOfType<AmbushPast>().setAmbush();
        }
        
    }
}
