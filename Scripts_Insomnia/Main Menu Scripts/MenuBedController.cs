using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBedController : MonoBehaviour
{
    public GameObject mouseOverObject;
    
    void Start()
    {

    }
    void OnMouseOver()
    {
        mouseOverObject.SetActive(true);
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Room");
            Cursor.visible = false;
        } 
    }

    void OnMouseExit()
    {
        mouseOverObject.SetActive(false); 
    }
}
