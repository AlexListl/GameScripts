using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    private Transform spawnPoint;

    private Animator anim;
    public bool isMoving = false;

    public float speed;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator> ();
        spawnPoint = this.GetComponent<Transform> ();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isMoving==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
        } */     
    }

    /*
    void onTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Flashlight")
        {
            gameObject.SetActive(false);
        }
    }


    public void moveTowardsPlayer()
    {
        isMoving = true;
        anim.SetTrigger("isMoving");
               
    }

    public void resetGhost()
    {
        transform.position = new Vector3 (spawnPoint.position.x,spawnPoint.position.y, spawnPoint.position.z);
    }
    */
}
