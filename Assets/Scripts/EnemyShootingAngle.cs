using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAngle : MonoBehaviour
{
    public GameObject bulletPrefab;  // ������ �������
    public Transform firePoint;  // �����, �� ������� ����� ������� ������
    public float shootInterval = 3f;  // �������� ����� ���������� (� ��������)
    public int numProjectiles = 8;  // ���������� ��������
    public float bulletSpeed = 1f;  // �������� �������

    private float nextShootTime;  // ����� ���������� ��������

    private void Start()
    {
        nextShootTime = Time.time;  // �������������� ����� ���������� ��������
    }

    private void Update()
    {
        // ���������, ������ �� ���������� ������� ��� ���������� ��������
        if (Time.time >= nextShootTime)
        {
            // ��������� ������� �� ��� �������
            for (int i = 0; i < numProjectiles; i++)
            {
                // ��������� ���� �������� ��� ������� �������
                float angle = i * (360f / numProjectiles);

                // ������� ������ �� �������
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, angle));

                // �������� ��������� Rigidbody2D �������
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                // ��������� ����������� �������� �������
                Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.right;

                // ������������� �������� �������� �������
                rb.velocity = direction * bulletSpeed;
            }

            // ��������� ����� ���������� ��������
            nextShootTime = Time.time + shootInterval;
        }
    }
}

