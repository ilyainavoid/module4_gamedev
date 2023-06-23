using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health, maxHealth;
    [SerializeField] private EnemyHealthBar healthBar;
    [SerializeField] private Spawner spawner;
    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateEnemyHealthBar(health);
        if (health <= 0)
        {
            //animation
            Destroy(gameObject);
            spawner.IncreaseKillCount();
        }
    }
}
