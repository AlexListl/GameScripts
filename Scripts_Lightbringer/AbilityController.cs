using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AbilityController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
    //public Animator animator;
    //public ParticleSystem healParticles;

    //public Light wrathLight;

    public int healCost;
    public float baseHeal;

    public int flamesCost;

    public int flashCost;
    public int flashRange;
    public float flashDamage;

    public LayerMask enemyLayers;
    public Transform attackPoint;
    

    GameObject[] healEffects;
    public VisualEffect innerFlames;

    public AnimationController animationController;
    
    void Start()
    {
        player = GameObject.Find("Player");

        baseHeal += (playerController.getMaxHealth()/100);
        flashDamage += (playerController.getAttackDamage()/10);
        
        innerFlames.Stop();

        healEffects = GameObject.FindGameObjectsWithTag("HealEffect");
        healEffects[1].GetComponent<VisualEffect>().Stop();
        healEffects[0].GetComponent<VisualEffect>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(FindObjectOfType<PlayerController>().getCurrentMana()>=healCost)
            {
                animationController.healAnimation();
                healPlayer();
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(FindObjectOfType<PlayerController>().getCurrentMana()>=flashCost)
            {
                animationController.flashAnimation();
                flashStrike();
            }
            
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(FindObjectOfType<PlayerController>().getCurrentMana()>=flamesCost)
            {
                animationController.flamesAnimation();
                activateFlames();
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<TimeTravelEvent>().timeTravel();
            StartCoroutine(WaitAMoment());    
        }   
    }

    void healPlayer(){

            playerController.increaseHealth(baseHeal);
            playerController.decreaseMana(healCost);

            foreach(GameObject heal in healEffects)
            {
                heal.GetComponent<VisualEffect>().Play();
            }         
    }
    
    void flashStrike(){

            playerController.decreaseMana(flashCost);

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, flashRange, enemyLayers);  

            foreach(Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyController>().playExplosion(FindObjectOfType<PlayerController>().getAttackDamage()/100*20+flashDamage);
            } 
    }

    void activateFlames()
    {
            playerController.decreaseMana(flamesCost);
            StartCoroutine(FlamesActive()); 
    }

    IEnumerator FlamesActive()
    {
        innerFlames.Play();
        playerController.increaseRegen(5);
        playerController.increaseAttackDamage(20);
        playerController.increaseMaxHealth(50);
        yield return new WaitForSeconds(15);
        playerController.decreaseRegen(5);
        playerController.decreaseAttackDamage(10);
        playerController.decreaseMaxHealth(50);
        innerFlames.Stop();
        FindObjectOfType<AudioManager>().Stop("FlamesActive");       
    }

    IEnumerator WaitAMoment()
    {
        yield return new WaitForSeconds(1);
        GetComponent<MovingScript>().timeWarp();
    }

    public void timeTravelForced()
    {
        FindObjectOfType<TimeTravelEvent>().timeTravel();
        StartCoroutine(WaitAMoment());
    }

    public int getHealCost()
    {
        return healCost;
    }
    public int getFlashCost()
    {
        return flashCost;
    }
    public int getFlamesCost()
    {
        return flamesCost;
    }

    public void setFlamesCost(int newCost)
    {
        flamesCost = newCost;
    }
}
