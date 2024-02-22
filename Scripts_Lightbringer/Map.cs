using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    GameObject[] mapObjects;
    bool showingMap;

    // Start is called before the first frame update
    void Start()
    {
        mapObjects = GameObject.FindGameObjectsWithTag("mapObject");
        hideMap();
        showingMap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
		{
			if(showingMap == false)
			{
				showMap();
			} else{
				hideMap();
			}
		}
    }

    public void showMap(){
        showingMap = true;
		foreach(GameObject g in mapObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hideMap(){
        showingMap = false;
		foreach(GameObject g in mapObjects){
			g.SetActive(false);
		}
	}
}
