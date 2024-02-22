using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideHint : MonoBehaviour
{
    public GameObject toolTipUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            toolTipUI.GetComponent<Canvas>().enabled = false;
        }
    }
}
