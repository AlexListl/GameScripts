using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    Scene currentScene;
    string currentSceneName;
    void Awake()
    {
        Cursor.visible = false;
        GetComponent<Canvas>().enabled = false;
    }
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void deathScreenActivation()
    {
        StartCoroutine(PlayerDeath());
    }

    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(8);
        GetComponent<Canvas>().enabled = true;
        Cursor.visible = true;
    }

    public void restartGame()
    {
        currentSceneName = currentScene.name;
		SceneManager.LoadScene(currentSceneName);
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
