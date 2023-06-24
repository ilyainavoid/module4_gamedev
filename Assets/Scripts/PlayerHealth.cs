using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthBar bar;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
       
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            //dead
            animator.SetTrigger("player_dies");
            //deathScreen
        }
        else
        {
            animator.SetTrigger("player_getsDamage");
        }
    }
    void Heal(int hp)
    {
        currentHealth += hp;
        healthBar.SetHealth(currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;  
        }
    }
}
