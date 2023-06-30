using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{

    public float maxMana = 100;
    public float currentMana;
    public ManaBar manaBar;
    void Start()
    {
        currentMana = maxMana;
        InvokeRepeating("ManaIncreasing", 0f, 1f);
    } 


    void ManaIncreasing()
    {
                if (currentMana < 100)
                {
                    
                    currentMana += 2.5f ;
                    manaBar.SetMana(currentMana);
                }
    }
    
    public void TakeMana(int mana)
    {
        currentMana -= mana;
        manaBar.SetMana(currentMana);
        if (currentMana <= 0)
        {
            //no more mana
        }
    }
    public void GetMana(int mana)
    {
        currentMana += mana;
        manaBar.SetMana(currentMana);
        if (currentMana > maxMana)
        {
            currentMana = maxMana;  
        }
    }
}
