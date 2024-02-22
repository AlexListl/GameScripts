using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChestController : MonoBehaviour
{
    public GameObject mouseOverObject;
    

    void Start()
    {

    }

    void Update()
    {

    }
    void OnMouseOver()
    {
        mouseOverObject.SetActive(true);        
    }
    
    void OnMouseExit()
    {
        mouseOverObject.SetActive(false);
    }
}
