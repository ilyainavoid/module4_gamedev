using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float attachmentDuration = 10f;  // ������������ ������������ ���� (� ��������)
    
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
        collider.isTrigger = false; // ��������� isTrigger � �������� false
        // ������� ������ �� ���� � ����������� ��� � ��� Transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Transform playerTransform = player.transform; // �������� transform ������
            Vector3 offset = transform.position - playerTransform.position; // ��������� �������� ������������ ������ ������
            offset = offset.normalized; // ����������� ������ ��������

            // ������������� ������� ������������ ������ ������ � ������ ��������
            transform.SetParent(playerTransform);
            transform.localPosition = offset;


            // ��������� �������� ��� ������� ������� ������������
            StartCoroutine(DetachAfterDuration());
        }
        else
        {
            Debug.LogError("����� �� ������!");
        }
    }

    private IEnumerator DetachAfterDuration()
    {
        // ���� �������� ������������ ������������
        yield return new WaitForSeconds(attachmentDuration);

        // ���������� ��� �� ������
        transform.SetParent(null);

        // ���������� ������ ����
        Destroy(gameObject);
    }
}