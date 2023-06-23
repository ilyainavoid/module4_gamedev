using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float damage = 10;
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
               enemyScript.TakeDamage(damage);
               break;
        }
    }
}
