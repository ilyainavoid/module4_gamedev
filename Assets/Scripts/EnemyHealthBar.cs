 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

 public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateEnemyHealthBar(float currentHealth )
    {
        slider.value = currentHealth;
    }
    void Update()
    {
        
    }
}
