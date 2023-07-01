using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAngle : MonoBehaviour
{
    public GameObject bulletPrefab;  // Префаб снаряда
    public Transform firePoint;  // Точка, из которой будет выпущен снаряд
    public float shootInterval = 3f;  // Интервал между выстрелами (в секундах)
    public int numProjectiles = 8;  // Количество снарядов
    public float bulletSpeed = 1f;  // Скорость снаряда

    private float nextShootTime;  // Время следующего выстрела

    private void Start()
    {
        nextShootTime = Time.time;  // Инициализируем время следующего выстрела
    }

    private void Update()
    {
        // Проверяем, прошло ли достаточно времени для следующего выстрела
        if (Time.time >= nextShootTime)
        {
            // Выпускаем снаряды во все стороны
            for (int i = 0; i < numProjectiles; i++)
            {
                // Вычисляем угол поворота для каждого снаряда
                float angle = i * (360f / numProjectiles);

                // Создаем снаряд из префаба
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, angle));

                // Получаем компонент Rigidbody2D снаряда
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                // Вычисляем направление движения снаряда
                Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.right;

                // Устанавливаем скорость движения снаряда
                rb.velocity = direction * bulletSpeed;
            }

            // Обновляем время следующего выстрела
            nextShootTime = Time.time + shootInterval;
        }
    }
}

