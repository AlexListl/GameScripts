using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    
    public void setMana(int mana){
        slider.value = mana;
    }

    public void setMaxMana(int mana){
        slider.maxValue = mana;
        slider.value = mana;
    }
}
