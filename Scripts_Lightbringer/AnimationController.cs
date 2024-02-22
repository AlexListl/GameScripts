using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animatorPlayer;
    List<string> comboList = new List<string>(new string[] {"playerLightAttack","playerLightAttack2","playerLightAttack3"});
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    float health;
    float attackDamage;

    public int comboNum;

    public float reset;

    public float resetTime;

    bool isInvincible = false;

    public VisualEffect explosionEffect;

    void Start()
    {
        explosionEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        health = GameObject.Find("Player").GetComponent<PlayerController>().getCurrentHealth();
        attackDamage = GameObject.Find("Player").GetComponent<PlayerController>().getAttackDamage();

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animatorPlayer.SetBool("isWalking", true);
        }else{
            animatorPlayer.SetBool("isWalking", false);
        }

        if((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && Input.GetButtonDown("Jump"))
        {
            animatorPlayer.SetTrigger("runJump");
        }

        if(!((Input.GetButton("Horizontal") || Input.GetButton("Vertical"))) && Input.GetButtonDown("Jump"))
        {
            animatorPlayer.SetTrigger("standJump");
        }

        if(health <= 0f)
        {
            animatorPlayer.SetTrigger("dying");
            FindObjectOfType<DeathController>().deathScreenActivation();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            animatorPlayer.SetTrigger("dodgeKey");
        }

        if(Input.GetButtonDown("Fire1") && comboNum < 3)
        {
            animatorPlayer.SetTrigger(comboList[comboNum]);
            comboNum++;
            reset = 0f;
        }
        if(comboNum>0)
        {
            reset += Time.deltaTime;
            if(reset > resetTime)
            {
                //animatorPlayer.SetTrigger("resetTrigger");
                comboNum=0;
            }
        }
        if(comboNum == 3)
        {
                resetTime = 3f;
                comboNum = 0;
        }
        else
        {
            resetTime = 2f;
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            animatorPlayer.SetTrigger("playerHeavyAttack");
        }
    }

    public void LightAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().takeDamage(attackDamage);
        }
    }

    public void HeavyAttack()
    {
        explosionEffect.Play();
        FindObjectOfType<AudioManager>().Play("FlashImpact");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange*3, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().takeDamage(attackDamage*2);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    public void healAnimation()
    {
        animatorPlayer.SetTrigger("healCast");
    }

    public void flashAnimation()
    {
        animatorPlayer.SetTrigger("flashCast");
    }

    public void flamesAnimation()
    {
        animatorPlayer.SetTrigger("flamesCast");
    }

    public void playerHurtAnimation()
    {
        if(Random.Range(0,100)<=FindObjectOfType<PlayerController>().getStaggerRate())
        {
            animatorPlayer.SetTrigger("playerHurt");
            comboNum = 0;
        }
    }

    public void invinciblity()
    {
        if(isInvincible == false)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
        
    }

    public bool getIsInvincible()
    {
        return isInvincible;
    }


    public void playSound(string soundName)
    {
        FindObjectOfType<AudioManager>().Play(soundName);
    }
}
