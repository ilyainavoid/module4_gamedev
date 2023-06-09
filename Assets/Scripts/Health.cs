using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
