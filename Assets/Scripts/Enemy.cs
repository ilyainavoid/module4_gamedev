using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health, maxHealth;
    [SerializeField] private EnemyHealthBar healthBar;
    [SerializeField] private Spawner spawner;
    public Mana playerMana;
    public int manaIncrease;
    public Animator animator;
    private int timer;
    private ScoreManager score;
    private void Awake()
    {
        score= FindObjectOfType<ScoreManager>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        spawner = FindAnyObjectByType<Spawner>();
    }
    void Start()
    {
        health = maxHealth;
        if (gameObject.CompareTag("Enemy"))
        {
            
        }
        else
        {
            if (timer > 3)
                        {
                            timer = 0;
                            InvokeRepeating("HealthIncreasing", 0f, 1f);
                        }
        }
    }
    
    void HealthIncreasing()
    {
        if (health < maxHealth)
        {
                    
            health += 2f;
            healthBar.UpdateEnemyHealthBar(health);
        }
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateEnemyHealthBar(health);
        if (health <= 0)
        {
            if (animator != null)
            {
                 animator.SetTrigger("isDead");
            }
            Destroy(gameObject);
            score.Kill();
            if (gameObject.CompareTag("Boss"))
            {
                // the end
            }
            playerMana.GetMana(manaIncrease);
        }
    }
}
