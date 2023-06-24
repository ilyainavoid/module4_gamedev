using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Weapon : MonoBehaviour
{
    public GameObject fireball;
    private Mana manaScript;
    private GameObject player;

    
    public Transform firePoint;
    public float fireForce;


    public void Start ()
    {
        player = GameObject.Find("Player");
        manaScript = player.GetComponent<Mana>();
        
    }

    public void Fire()
    {
        if (manaScript.currentMana > 0)
        {
            
            GameObject projectile = Instantiate(fireball, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            manaScript.TakeMana(10);
        }
    }
}