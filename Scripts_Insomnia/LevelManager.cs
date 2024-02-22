using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int lives, batteries;
    public float respawnDelay;
    public float gameOverTime;
    public PlayerController gamePlayer;
    public DeathMessage messageDeath;
    public GameOverScript messageGameOver;

    


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        batteries = 3;
        gamePlayer = FindObjectOfType<PlayerController> ();
        messageDeath = FindObjectOfType<DeathMessage> ();
        messageGameOver = FindObjectOfType<GameOverScript> ();
        FindObjectOfType<AudioManager> ().music("backgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        if(lives>0)
        {
            gamePlayer.gameObject.SetActive(false);
            messageDeath.showMessage();
            yield return new WaitForSeconds(respawnDelay);
            gamePlayer.transform.position = gamePlayer.respawnPoint;
            gamePlayer.gameObject.SetActive(true);
            messageDeath.showMessage();
            lives--;
        }
        else
        {
            messageGameOver.showMessage();
            yield return new WaitForSeconds(gameOverTime);
            
            //Code bei Game Over
            SceneManager.LoadScene("Room");
        }
        
    }

    public int getNumberOfLives(){
        return lives;
    }

    public int getNumberOfBattery()
    {
        return batteries;
    }



    public void reduceCharges()
    {
        this.batteries--;
    }

    public void setCharges(int charges)
    {
        this.batteries = charges;
    }
}
