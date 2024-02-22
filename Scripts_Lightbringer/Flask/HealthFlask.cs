using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFlask : MonoBehaviour
{

    GameObject thisFlask;
    PlayerController playerController;

    public float amount;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        amount = 30;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerController.increaseHealth(amount);
            FindObjectOfType<AudioManager>().Play("HealthFlask");
            Destroy(gameObject);
        }
    }
}
