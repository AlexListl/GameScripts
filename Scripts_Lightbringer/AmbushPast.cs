using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushPast : MonoBehaviour
{
    bool ambush = false;
    Component[] timeScripts;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player")
        {
            StartCoroutine(timetravelAmbush());
        }
        
    }

    public bool getAmbush()
    {
        return ambush;
    }

    public void setAmbush()
    {
        ambush = true;
    }

    IEnumerator timetravelAmbush()
    {
            FindObjectOfType<AbilityController>().timeTravelForced();
             yield return new WaitForSeconds(3);
             ambush = true;
    }
}
