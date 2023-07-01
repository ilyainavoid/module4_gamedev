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
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("isAttacked");
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
            playerMana.GetMana(manaIncrease);
        }
    }
}
