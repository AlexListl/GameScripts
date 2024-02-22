using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("gameLaunch");
    }

    IEnumerator gameLaunch(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
    
}
