using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTravelEvent : MonoBehaviour
{
    public Animator timeAnimator;

    public void timeTravel()
    {
        if(FindObjectOfType<AmbushPast>().getAmbush()==false)
        {
            Time.timeScale = 0;
            timeAnimator.SetTrigger("timetravel");
            FindObjectOfType<AudioManager>().Play("TimeTravel");
            Time.timeScale = 1;
        }
        
    }
}
