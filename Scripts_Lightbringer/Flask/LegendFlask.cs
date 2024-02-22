using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendFlask : MonoBehaviour
{
    GameObject thisFlask;
    PlayerController playerController;

    public int healthIncrease;
    public int attackDamageIncrease;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        healthIncrease = 50;
        attackDamageIncrease = 10;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerController.increaseMaxHealth(healthIncrease);
            playerController.increaseAttackDamage(attackDamageIncrease);
            FindObjectOfType<TooltipTrigger>().flaskText("This is a Legendary Flask!\nIt permantly increases your\nMaximum Health and Attack Damage!");
            FindObjectOfType<AudioManager>().Play("LegendFlask");
            Destroy(gameObject);
        }
    }
}
