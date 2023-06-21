using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour
{
    public int damageAmount = 10;  // ���������� �����, ��������� ��� �������
    
    private void Update()
    {
        // ��������� ������ �������, ������������ �� ������
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // ������� ��� �� ������� �������
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // ���������, ������������ �� ��� � �������
                if (Physics.Raycast(ray, out hit))
                {
                    // ���������, �������� �� ������������ � �������
                    if (hit.collider.CompareTag("Player"))
                    {
                        // ���� ��� ���, ������� ���� ������
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
