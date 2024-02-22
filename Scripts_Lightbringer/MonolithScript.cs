using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithScript : MonoBehaviour
{
    bool playerNearMonolith;
    public Material newMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && playerNearMonolith==true)
            {
                FindObjectOfType<AbilityController>().setFlamesCost(4);
                GameObject.FindGameObjectWithTag("Monolith").GetComponent<Renderer>().material = newMaterial;
                FindObjectOfType<TooltipTrigger>().showToolTipWithoutTrigger("You now have access to Inner Flames\nwhich grants you Health and\nAttack Damage Increases for a short time");
            }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player")
        {
            playerNearMonolith = true;
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.name == "Player")
        {
            playerNearMonolith = false;
        }
        
    }
}
