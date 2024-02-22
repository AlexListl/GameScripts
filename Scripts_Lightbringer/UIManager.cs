using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    Scene currentScene;
    string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
		hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
		if(Input.GetKeyDown("escape"))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
				Cursor.visible = true;
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
				Cursor.visible = false;
			}
		}
    }

    //Reloads the Level
	public void Reload(){
        currentSceneName = currentScene.name;
		SceneManager.LoadScene(currentSceneName);
	}

	//controls the pausing of the scene
	public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){
		SceneManager.LoadScene(level);
	}

    public void ExitGame(){
        Application.Quit();
    }
}
