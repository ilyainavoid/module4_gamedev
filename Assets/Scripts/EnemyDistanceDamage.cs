using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public GameObject bulletPrefab; // ������ ����
    public float bulletSpeed = 20f; // �������� ����
    public float shootingInterval = 1f; // �������� ����� ����������

    private float shootingTimer = 0f; // ������ ��� �������� ��������� ����� ����������

    private void Update()
    {
        // ���������, ���� ����� �� ������� � ��� ������ ������ ���������
        if (player != null && shootingTimer >= shootingInterval)
        {
            // ������������ ����������� � ���� �� ���� (������)
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ������� ���� � ������������� �� ������� � �������
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, angle));

            // ������ �������� ����
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = direction * bulletSpeed;

            // ���������� ������ ��������
            shootingTimer = 0f;
        }

        // ����������� ������ ��������
        shootingTimer += Time.deltaTime;
    }
}



