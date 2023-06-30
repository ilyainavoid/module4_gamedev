using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Snowflake : MonoBehaviour
{
    public Rigidbody2D rb;
    public float damage = 7;
    void OnTriggerEnter2D(Collider2D other) 
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                Destroy(gameObject);
                Enemy enemyScript = other.GetComponent<Enemy>();
                AIPath enemySpeed = other.GetComponent<AIPath>();
                enemySpeed.maxSpeed *= 0.5f;
                enemyScript.TakeDamage(damage);
                break;
        }
    }
}
