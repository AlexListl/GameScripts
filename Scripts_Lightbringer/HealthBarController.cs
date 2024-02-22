using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    
    public void setHealth(float health){
        slider.value = health;
    }

    public void setMaxHealth(float maxHealth){
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
