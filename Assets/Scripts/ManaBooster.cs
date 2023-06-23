using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBooster : MonoBehaviour
{
    private Mana mana;

    public int manaBoost;

    private void Awake()
    {
        mana = FindObjectOfType<Mana>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (mana.currentMana < mana.maxMana)
        {
            Destroy(gameObject);
            mana.GetMana(manaBoost);
        }
    }
}
