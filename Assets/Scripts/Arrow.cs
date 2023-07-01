  using System;
  using System.Collections;
using System.Collections.Generic;
  using Unity.VisualScripting;
  using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force = 7;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float angle = MathF.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle + 180);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = player.GetComponentInChildren<PlayerHealth>(); 
            health.TakeDamage(25);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
    }
}
