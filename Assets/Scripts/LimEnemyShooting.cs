 using System.Collections;
using System.Collections.Generic;
 using Unity.Mathematics;
 using Unity.VisualScripting;
 using UnityEngine;

public class LimEnemyShooting : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPos;
    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 10)
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
        Instantiate(arrow, arrowPos.position, Quaternion.identity);
         
    }
}
