using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMessage : MonoBehaviour
{
    public Text message;

    public void showMessage()
    {
        if(message.enabled == false)
        {
            message.enabled = true;
        }else{
            message.enabled = false;
        }
    }
}
