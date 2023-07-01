 using System.Collections;
using System.Collections.Generic;
 using Unity.Mathematics;
 using Unity.VisualScripting;
 using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject weapon;
    public Transform weaponPos;
    private float timer;
    public float viewDistance;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < viewDistance)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0; 
                 Shoot();
            }
        }
        
    }

    private void Shoot()
    {
        Instantiate(weapon, weaponPos.position, Quaternion.identity);
         
    }
}
