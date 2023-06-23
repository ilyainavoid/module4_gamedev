using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{

    public int maxMana = 100;
    public int currentMana;
    public ManaBar manaBar;
    void Start()
    {
        currentMana = maxMana;
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
