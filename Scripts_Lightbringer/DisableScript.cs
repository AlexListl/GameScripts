using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    public GameObject healthBar;

    public void disableEnemyBar()
    {
        healthBar.SetActive(false);
    }
    
}
