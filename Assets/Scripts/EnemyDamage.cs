using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    private bool isColliding;
    private float damageTimer;
    private float damageInterval = 0.3f;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (isColliding)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(damage);
                damageTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = false;
            damageTimer = 0f;
        }
    }
}
