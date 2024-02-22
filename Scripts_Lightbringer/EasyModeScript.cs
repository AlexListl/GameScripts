using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyModeScript : MonoBehaviour
{

    public GameObject legendFlask;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.name =="Player")
        {
            Instantiate(legendFlask, this.transform.position + new Vector3(5,5,5), Quaternion.identity);
        }
    }
}
