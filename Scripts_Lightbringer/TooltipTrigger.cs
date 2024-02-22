using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour
{

    public Text tooltipText;
    string[] toolTips = new string[20];
    public int number;
    bool potionHit = false;

    void Start()
    {
        toolTips[0] = "Use LMB for Light Attacks!\nUse RMB for Heavy Attacks\nGood Timing will Trigger Combos";
        toolTips[1] = "Use Q for your first Ability!\nIn this tutorial your first Ability is a small Heal!\n";
        toolTips[2] = "Use E for your second Ability!\nIn this tutorial your second Ability is large Area, hard-hitting Flash Attack!";
        toolTips[3] = "Watch out for your Mana Consumption!\nEach Spell costs a certain amount of Mana!";
        toolTips[4] = "You are a Protector of Time and \nas such you can TIME TRAVEL\nUse F to Time Travel";
        toolTips[5] = "Using Time Travel shifts you backwards\nor forwards in time but not in space!\nShifting in Time opens up new pathways!";
        toolTips[6] = "This is a Monolith of the Past.\nYou can absorb its power!\nPress T to absorb!";
        toolTips[7] = "Some enemies are stronger then others.\nSome hit harder, others can use Magic.\nBe aware of your Health Bar!";
        toolTips[8] = "Watch out!\nThe Demons have trapped you at their portal!\nDefeat the waves to end the tutorial!";
        toolTips[9] = "You now gave access to Inner Flames\nInner Flames increases Health\nand Attack Power for a short time!";
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player")
        {
            GameObject.FindGameObjectWithTag("TextUI").GetComponent<Canvas>().enabled = true;
            setToolTipText(toolTips[number]);
        }
    }

    void setToolTipText(string tooltip)
    {
        tooltipText.text = tooltip;
        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;
    }

    public void showToolTipWithoutTrigger(string text)
    {
        GameObject.FindGameObjectWithTag("TextUI").GetComponent<Canvas>().enabled = true;
        setToolTipText(text);
    }

    public void flaskText(string text)
    {
        if(!potionHit)
        {
            showToolTipWithoutTrigger(text);
            potionHit = true;
        }
    }


}
