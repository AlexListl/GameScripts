using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    bool playerCollsion;
    // Start is called before the first frame update
    void Start()
    {
        playerCollsion = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerCollsion = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerCollsion = false;
        }
    }

    public bool getIsInCone()
    {
        return playerCollsion;
    }
}
