using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private HealthBar bar;
    public int maxHealth = 100;
    public int currentHealth;
    
    void Start()
    {
        bar = GetComponent<HealthBar>();
        bar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bar.SetHealth(currentHealth);
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
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;  
        }
    }
}
