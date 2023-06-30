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

    public GameObject shield;
    private bool isShieldActive = false;
    private float shieldDuration = 10f; 
    private float shieldTimer = 0f;
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

        if (isShieldActive)
        {
            shieldTimer += Time.deltaTime;

            if (shieldTimer >= shieldDuration)
            {
                DisableShield();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!isShieldActive && manaScript.currentMana >= 40)
            {
                EnableShield();
                
                manaScript.TakeMana(40);
            }
        }
    }
    private void EnableShield()
    {
        isShieldActive = true;
        shield.SetActive(true);
        shieldTimer = 0f;
    }

    private void DisableShield()
    {
        isShieldActive = false;
        shield.SetActive(false);
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