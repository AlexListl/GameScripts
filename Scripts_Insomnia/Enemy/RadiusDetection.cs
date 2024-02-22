using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusDetection : MonoBehaviour
{
    public EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = FindObjectOfType<EnemyController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!FindObjectOfType<AudioManager>().isPlaying("ghostLaught"))
            {
                FindObjectOfType<AudioManager>().Play("ghostLaught");
            }
            //enemyController.moveTowardsPlayer();
        }
        
    }
}
