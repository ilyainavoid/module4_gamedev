using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthBar bar;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        bar = GetComponent<HealthBar>();
        bar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            //dead
            //animation
            //deathScreen
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
