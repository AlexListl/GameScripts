using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    //public Image life_One;
    //public bool imageState = true;

    public GameObject life_One, life_Two, life_Three;
    public GameObject battery;
    public Sprite batteryFull, batteryHalf, batteryEmpty;
    public LevelManager levelManager;
    private Image image;
    
 
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        life_One.gameObject.SetActive (true);
        life_Two.gameObject.SetActive (true);
        life_Three.gameObject.SetActive (true);

        battery.gameObject.SetActive (true);
        image = battery.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(levelManager.getNumberOfLives())
        {
            case 3: 
                life_One.gameObject.SetActive (true);
                life_Two.gameObject.SetActive (true);
                life_Three.gameObject.SetActive (true);
                break;
            case 2:
                life_Three.gameObject.SetActive (false);
                break;
            case 1:
                life_Two.gameObject.SetActive (false);
                life_Three.gameObject.SetActive (false);
                break;
            case 0:
                life_One.gameObject.SetActive (false);
                life_Two.gameObject.SetActive (false);
                life_Three.gameObject.SetActive (false);
                break;
            default:
                life_One.gameObject.SetActive (true);
                life_Two.gameObject.SetActive (true);
                life_Three.gameObject.SetActive (true);
                break;
        }

        switch(levelManager.getNumberOfBattery())
        {
            case 3:
                battery.gameObject.SetActive(true);
                image.sprite = batteryFull;
                
                break;
            case 2:
                image.sprite = batteryHalf;
                break;
            case 1:
                image.sprite = batteryEmpty;
                
                break;
            case 0:
                battery.gameObject.SetActive(false);
                
                break;
            default:
                battery.gameObject.SetActive(true);
                image.sprite = batteryEmpty;
                break;
        }
        
    }
}
