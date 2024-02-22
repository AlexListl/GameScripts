using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;
    public float attackRange;
    public float attackDamage;

    public float castDamage;

    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public HealthBarController healthBarController;

    
    void Start()
    {
        Debug.Log(maxHealth);
        currentHealth = maxHealth;
        healthBarController.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //healthBarController.setHealth(currentHealth);
    }

    public float getMaxHealth(){
        return maxHealth;
    }
    public float getCurrentHealth(){
        return currentHealth;
    }

    public void getDamage(float damage)
    {
        currentHealth -= damage; 
    }

    public float getAttackRange(){
        return attackRange;
    }
    
    public float getAttackDamage(){
        return attackDamage;
    }

    public float getCastDamage(){
        return castDamage;
    }

    public float getAttackRate()
    {
        return attackRate;
    }

    public float getNextAttackTime(){
        return nextAttackTime;
    }

    public void setNextAttackTime(float nextTime){
        nextAttackTime = nextTime;
    }
}
