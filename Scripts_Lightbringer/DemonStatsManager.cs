using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonStatsManager : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public float attackDamage;
    public float castDamage;
    public float attackRange;

    public float attackRate;

    public float nextAttackTime = 0f;

    public HealthBarController healthBarController;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarController.setMaxHealth(maxHealth);
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
        healthBarController.setHealth(currentHealth);
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
