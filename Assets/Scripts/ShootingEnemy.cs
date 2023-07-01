using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Shield":
                Destroy(gameObject);
                break;
            case "Player":
                Destroy(gameObject);
                PlayerHealth hp = other.GetComponent<PlayerHealth>();
                hp.TakeDamage(damage);
                break;
        }
    }
}
