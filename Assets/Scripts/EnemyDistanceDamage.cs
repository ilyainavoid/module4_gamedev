using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public GameObject bulletPrefab; // Префаб пули
    public float bulletSpeed = 20f; // Скорость пули
    public float shootingInterval = 1f; // Интервал между выстрелами

    private float shootingTimer = 0f; // Таймер для контроля интервала между выстрелами

    private void Update()
    {
        // Проверяем, если игрок не нулевой и наш таймер достиг интервала
        if (player != null && shootingTimer >= shootingInterval)
        {
            // Рассчитываем направление и угол на цель (игрока)
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Создаем пулю и устанавливаем ее позицию и поворот
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, angle));

            // Задаем скорость пули
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = direction * bulletSpeed;

            // Сбрасываем таймер выстрела
            shootingTimer = 0f;
        }

        // Увеличиваем таймер выстрела
        shootingTimer += Time.deltaTime;
    }
}



