using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilityController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ability1;
    int ability1Cost;
    public Image ability2;
    int ability2Cost;
    public Image ability3;
    int ability3Cost;

    int mana;

    // Update is called once per frame
    void Update()
    {
        mana = FindObjectOfType<PlayerController>().getCurrentMana();
        ability1Cost = FindObjectOfType<AbilityController>().getHealCost();
        ability2Cost = FindObjectOfType<AbilityController>().getFlashCost();
        ability3Cost = FindObjectOfType<AbilityController>().getFlamesCost();

        abilityIsUsable(mana,ability1, ability1Cost);
        abilityIsUsable(mana,ability2, ability2Cost);
        abilityIsUsable(mana,ability3, ability3Cost);
    }

    void abilityIsUsable(int mana, Image image, int cost)
    {
        if(mana<cost)
        {
            var color = image.color;
            color.a = 0;
            image.color = color;

        }else if(mana>=cost)
        {
            var color = image.color;
            color.a = 1;
            image.color = color;
        }
    }
}
