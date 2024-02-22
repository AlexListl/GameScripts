using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClosetController : MonoBehaviour
{
    public GameObject mouseOverObject;
    

    void Start()
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
