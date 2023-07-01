using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public GameObject[] weapons;
    public Transform weaponPos;
    private float timer;
    public float viewDistance;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
    }
    
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < viewDistance)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
        {
            int random = Random.Range(0, weapons.Length);
            Instantiate(weapons[random], weaponPos.position, Quaternion.identity);
         
        }
}
