using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaFlask : MonoBehaviour
{
    GameObject thisFlask;
    PlayerController playerController;

    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        amount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerController.increaseMana(amount);
            FindObjectOfType<AudioManager>().Play("ManaFlask");
            Destroy(gameObject);
        }
    }
}
