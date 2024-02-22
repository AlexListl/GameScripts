using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float regenRate;
    
    public float staggerRate;

    public int maxMana;
    public int currentMana;

    public float attackDamage;

    private bool isRegeneratingHealth = false;
    private bool isRegeneratingMana = false;

    public HealthBarController healthBar;
    public ManaBarController manaBar;
 
    private void Start()
    {
        currentMana = maxMana;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        manaBar.setMaxMana(maxMana);
    }
 
    void Update()
    {
        if(currentHealth<maxHealth && isRegeneratingHealth == false)
        {
            isRegeneratingHealth = true;
            StartCoroutine(RegenHealth());
        }

        if(currentMana<maxMana && isRegeneratingMana == false)
        {
            isRegeneratingMana = true;
            StartCoroutine(RegenMana());
        }

        if(Input.GetKeyDown(KeyCode.L)){
            decreaseHealth(20);
        }

        healthBar.setHealth(currentHealth);
        manaBar.setMana(currentMana);
    }

    public void decreaseHealth(float damage){
        if(FindObjectOfType<AnimationController>().getIsInvincible() ==false)
        currentHealth -= damage;
        FindObjectOfType<AnimationController>().playerHurtAnimation();
    }

    

    public void increaseHealth(float heal){
        
        if(currentHealth+heal>maxHealth)
        {
            currentHealth = maxHealth;
        }else{
            currentHealth += heal;
        }   
    }

    public void decreaseMana(int manaUse){
        currentMana -= manaUse;
    }

    public void increaseRegen(float amount){
        regenRate += amount;
    }

    public void decreaseRegen(float amount){
        regenRate -= amount;
    }

    public float getStaggerRate()
    {
        return staggerRate;
    }

    public void increaseMana(int manaGain)
    {
        if(currentMana+manaGain>maxMana)
        {
            currentMana = maxMana;
        }else{
            currentMana += manaGain;
        }
        
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }
    public int getCurrentMana()
    {
        return currentMana;
    }

    public float getAttackDamage()
    {
        return attackDamage;
    }

    public void increaseAttackDamage(float amount)
    {
        attackDamage += amount;
    }

    public void decreaseAttackDamage(int amount)
    {
        attackDamage -= amount;
    }

    public void increaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    public void decreaseMaxHealth(float amount){
        maxHealth -= amount;
    }

    IEnumerator RegenHealth()
    {
        currentHealth += regenRate;
        yield return new WaitForSeconds(1);
        isRegeneratingHealth = false;
    }

    IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(10);
        currentMana += 1;
        isRegeneratingMana = false;
    }

}
