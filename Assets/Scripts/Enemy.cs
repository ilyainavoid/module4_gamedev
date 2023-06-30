using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health, maxHealth;
    [SerializeField] private EnemyHealthBar healthBar;
    public Mana playerMana;
    public int manaIncrease;
    public Animator animator;

    private ScoreManager score;
    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        score= FindObjectOfType<ScoreManager>();
    [SerializeField] private Spawner spawner;
    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
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
            animator.SetBool("IsDead", true);
            Destroy(gameObject);
            score.Kill();
            spawner.IncreaseKillCount();
            playerMana.GetMana(manaIncrease);
        }
    }
}
