using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float attachmentDuration = 10f;  // Длительность прикрепления щита (в секундах)
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            AttachToPlayer();
        }
    }
    private void AttachToPlayer()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = false; // Установка isTrigger в значение false
        // Находим игрока по тегу и прикрепляем щит к его Transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Transform playerTransform = player.transform; // Получаем transform игрока
            Vector3 offset = transform.position - playerTransform.position; // Вычисляем смещение относительно центра игрока
            offset = offset.normalized; // Нормализуем вектор смещения

            // Устанавливаем позицию относительно центра игрока с учетом смещения
            transform.SetParent(playerTransform);
            transform.localPosition = offset;


            // Запускаем корутину для отсчета времени прикрепления
            StartCoroutine(DetachAfterDuration());
        }
        else
        {
            Debug.LogError("Игрок не найден!");
        }
    }

    private IEnumerator DetachAfterDuration()
    {
        // Ждем заданную длительность прикрепления
        yield return new WaitForSeconds(attachmentDuration);

        // Открепляем щит от игрока
        transform.SetParent(null);

        // Уничтожаем объект щита
        Destroy(gameObject);
    }
}