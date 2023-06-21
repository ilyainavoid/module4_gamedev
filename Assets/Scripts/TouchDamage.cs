using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour
{
    public int damageAmount = 10;  // Количество урона, наносимое при касании
    
    private void Update()
    {
        // Проверяем каждое касание, происходящее на экране
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Создаем луч от позиции касания
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Проверяем, сталкивается ли луч с игроком
                if (Physics.Raycast(ray, out hit))
                {
                    // Проверяем, является ли столкновение с игроком
                    if (hit.collider.CompareTag("Player"))
                    {
                        // Если это так, наносим урон игроку
                        Health playerHealth = hit.collider.GetComponent<Health>();
                        if (playerHealth != null)
                        {
                            playerHealth.TakeDamage(damageAmount);
                        }
                    }
                }
            }
        }
    }
    
}
