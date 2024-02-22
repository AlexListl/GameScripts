using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Renderer rend;
    public float speed;
    public float jumpForce;
    public float kneelTime;
    public float cryTime;
    private float moveInput;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    private Animator anim;
    private bool isJumping;
    private bool isWalking;
    public bool isHidden;
    public float maxSpeed;
    public float acceleration;

    private bool facingRight;
    public bool frozen = false;

    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    public FlashLightController flashlightController;

    public GameObject currentInteractionObject = null;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameLevelManager = FindObjectOfType<LevelManager> ();
        flashlightController = FindObjectOfType<FlashLightController> ();
    }

    private void FixedUpdate()
    {
        if (!frozen) {
            if (Input.GetButton("Horizontal")&&(speed < maxSpeed))
            {
                speed = speed + acceleration;
            }
            if (!Input.GetButton("Horizontal"))
            {
                speed = 0;
            }
            
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            Flip(moveInput);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!frozen) {
           

            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

            if (!isGrounded && !isJumping)
            {
                anim.SetBool("isFalling", true);
            }

            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("takeOf");
                FindObjectOfType<AudioManager>().Play("jumpStartSound");
                isJumping = true;
            }
            

            if (isGrounded == true && (Input.GetButton("Horizontal")))
            {
                anim.SetTrigger("walkStart");
                if(!FindObjectOfType<AudioManager>().isPlaying("walkingSound"))
                    FindObjectOfType<AudioManager>().Play("walkingSound");
                anim.SetBool("isWalking", true);
            }
            else if(!isGrounded || !(Input.GetButton("Horizontal"))){
                FindObjectOfType<AudioManager>().Stop("walkingSound");
            }
           

            if (isHidden && Input.GetButton("Horizontal"))
            {
                rend.enabled = true;
                isHidden = false;
                Debug.Log("HelloAgain");
            }

            if (Input.GetButton("Interact") && currentInteractionObject)
            {
                if (currentInteractionObject.name == "Bed_withChar-01_6")
                {

                    currentInteractionObject.SendMessage("Sleep");
                    isHidden = true;
                    
                    


                }
            }
            if (isHidden)
            {
                rend.enabled = false;
            }

        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            isJumping = false;
        }
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
        }

        if (!Input.GetButton("Horizontal"))
        {

            anim.SetBool("isWalking", false);
            anim.SetTrigger("toIdle");

        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(gameLevelManager.getNumberOfBattery()>0)
            {
                StartCoroutine("switchFlashlight");
            }
        }



    }

    IEnumerator switchFlashlight()
    {
        anim.SetBool("torchUp", true);
        anim.SetTrigger("torchOut");
        yield return new WaitForSeconds(0.7f);
        flashlightController.switchLight();
        gameLevelManager.reduceCharges();
        yield return new WaitForSeconds(3f);
        flashlightController.switchLight();
        anim.SetBool("torchUp", false);
    }


    void startJump()
    {
        rb.velocity = Vector2.up * jumpForce;
        isJumping = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("HorizontalPlatform"))
        {
            collision.transform.parent = GameObject.Find("PlatformHorizontal").transform;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interObject"))
        {
            currentInteractionObject = collision.gameObject;

        }

        if(collision.tag=="Killfloor")
        {
            FindObjectOfType<AudioManager>().Play("deathSound");
            gameLevelManager.setCharges(3);
            gameLevelManager.Respawn();
        }
        if(collision.tag == "Checkpoint")
        {
            gameLevelManager.setCharges(3);
            respawnPoint = collision.transform.position;
        }

        if(collision.tag=="CutsceneTrigger")
        {
            StartCoroutine("cutsceneStart");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interObject"))
        {
            currentInteractionObject = null;

        }
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    IEnumerator cutsceneStart()
    {
        anim.SetTrigger("GetOnKnee");
        yield return new WaitForSeconds(kneelTime);
        anim.SetTrigger("GetUpKnee");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("StartCrying");
    }

    public void StopAllMovement()
    {
        rb.velocity = Vector2.zero;
        Debug.Log("stopping");
    }




}
