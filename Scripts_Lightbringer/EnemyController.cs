using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class EnemyController : MonoBehaviour
{
    DemonStatsManager demonStatsManager;
    public Animator demonAnimator;    
    public Transform playerDetect;
    public float detectionRange;
    public LayerMask player;
    bool playerDetected = false;

    Transform target;
    NavMeshAgent agent;

    public Transform attackPoint;

    public VisualEffect explosionEffect;
    public VisualEffect fireCastEffect;

    public GameObject healthFlask;
    public GameObject manaFlask;

    float randomSpawner;
    float randomAttack;

    public bool isEmpowered;
    public bool isCaster;
    float distance;

    AudioManager enemyAudio; 
    

    void Start()
    {
        enemyAudio = FindObjectOfType<AudioManager>();
        randomSpawner = Random.Range(0,100);
        demonStatsManager = GetComponent<DemonStatsManager>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        explosionEffect.Stop();
        fireCastEffect.Stop();
    }

    void Update()
    {
        randomAttack = Random.Range(0,100);

        distance = Vector3.Distance(target.position, transform.position);

        if (distance-4 <= detectionRange){
            
            //Roar then set Target then start running
            FaceTarget();

            if(playerDetected == false)
            {
                roar();
                playerDetected = true;
            }

            if(playerDetected==true)
            {
                AttackRoutine();
            }

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if(Time.time >= demonStatsManager.getNextAttackTime()){
                    if(randomAttack<=10)
                    {
                        demonAnimator.SetTrigger("demonCombo");

                    }
                    else if(isEmpowered == true && randomAttack>=70)
                    {
                        demonAnimator.SetTrigger("demonHeavyAttack");
                    }
                    else if(isCaster == true && randomAttack>=60)
                    {
                        demonAnimator.SetTrigger("demonFire");
                        enemyAudio.Play("DemonCast");
                    }
                    else
                    {
                        demonAnimator.SetTrigger("demonLightAttack");
                    }
                    demonStatsManager.setNextAttackTime(Time.time +4f / demonStatsManager.getAttackRate());
                }
                
            }
        }
    }

    //Take Damage Method
    public void takeDamage(float damage)
    {
        
        demonStatsManager.getDamage(damage);
        enemyAudio.Play("HitEnemy");

        demonAnimator.SetTrigger("demonHurt");

        if(isCaster && isEmpowered)
            {
                enemyAudio.Play("DemonBossHurt");
            }
            else if(isEmpowered)
            {
                enemyAudio.Play("DemonBigHurt");
            }
            else
            {
                enemyAudio.Play("DemonHurt");
                fireCastEffect.Stop();
            }

        if(demonStatsManager.getCurrentHealth()<= 0)
        {
            die();
        }
    }


    //Method for Death of Demon
    void die()
    {
        //Animation Trigger
        demonAnimator.SetTrigger("demonDeath");
        fireCastEffect.Stop();

        if(isCaster && isEmpowered)
            {
                enemyAudio.Play("DemonBossDeath");
            }
            else if(isEmpowered)
            {
                enemyAudio.Play("DemonBigDeath");
            }
            else
            {
                enemyAudio.Play("DemonDeath");
            }
        //Disable Demon Collider,Bar and Script
        spawnFlask();
        GetComponent<DisableScript>().disableEnemyBar();
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
        
    }

    //Trigger Roar Animation and Values
    void roar()
    {
            //Animation Trigger
            demonAnimator.SetTrigger("demonRoar");
            if(isCaster && isEmpowered)
            {
                enemyAudio.Play("DemonRoarBoss");
            }
            else if(isEmpowered)
            {
                enemyAudio.Play("DemonRoarBig");
            }
            else
            {
                enemyAudio.Play("DemonRoar");
            }
            StartCoroutine(waitForSeconds(2));                  
    }

    void AttackRoutine(){
        agent.SetDestination(target.position);
        demonAnimator.SetTrigger("demonIsRunning");
    }

    //Method to Face Player
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackPlayer()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, GetComponent<DemonStatsManager>().getAttackRange(), player);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerController>().decreaseHealth(demonStatsManager.getAttackDamage());
            enemyAudio.Play("DemonHeavyAttack");
        }
    }

    void FireCast()
    {
        if(FindObjectOfType<PlayerDetection>().getIsInCone()==true)
        {
            FindObjectOfType<PlayerController>().decreaseHealth(demonStatsManager.getCastDamage());
        }
    }

    public void playExplosion(float damage)
    {
        StartCoroutine("Explosion", damage);
    }


    void spawnFlask()
    {
        if(randomSpawner<=10)
        {
            Instantiate(healthFlask, attackPoint.position + new Vector3(0,3,0), Quaternion.identity);
        }
        else if(randomSpawner>70 && isEmpowered)
        {
            Instantiate(healthFlask, attackPoint.position + new Vector3(0,3,0), Quaternion.identity);
        }
        else if(randomSpawner>10 && randomSpawner<=20)
        {
            Instantiate(manaFlask, attackPoint.position + new Vector3(0,3,0), Quaternion.identity);
        }
        else if(randomSpawner>10 && randomSpawner<=40 && isCaster)
        {
            Instantiate(manaFlask, attackPoint.position + new Vector3(0,3,0), Quaternion.identity);
        }
        
    }

    //Method to draw detectionRange
    void onDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    IEnumerator Explosion(float damage)
    {
        yield return new WaitForSeconds(2);
        explosionEffect.Play();
        enemyAudio.Play("FlashImpact");
        this.takeDamage(damage);
    }

    public void FireEffect()
    {
        fireCastEffect.Play();
    }

    public void FireEffectEnd()
    {
        fireCastEffect.Stop();
    }

    IEnumerator waitForSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void playSound(string soundName)
    {
        enemyAudio.Play(soundName);
    }

    public void portalAttack()
    {
        agent.SetDestination(target.position);
        demonAnimator.SetTrigger("demonIsRunning");
    }

}
