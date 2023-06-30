using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{

    private Mana manaScript;
    private GameObject player;
    private int totalWeapons = 2;
    public int manaTake = 10;
    private GameObject currentGun;
    public GameObject[] guns;
    public int currentWeaponIndex;
    
    public Transform firePoint;
    public float fireForce;


    public void Start ()
    {
        currentGun = guns[0];
        currentWeaponIndex = 0;
        player = GameObject.Find("Player");
        manaScript = player.GetComponent<Mana>();  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
            currentGun = guns[currentWeaponIndex];
            manaTake = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
            currentGun = guns[currentWeaponIndex];
            manaTake = 15;
        }
    }

    public void Fire()
    {
        if (manaScript.currentMana > 0)
        {
            GameObject projectile = Instantiate(currentGun, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            manaScript.TakeMana(manaTake);
        }
    }
}