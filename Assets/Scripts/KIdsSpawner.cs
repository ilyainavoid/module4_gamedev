using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIdsSpawner : MonoBehaviour
{
    public GameObject[] kids;
    private float randomX, randomY;
    private float timer;
    private Vector2 whereToSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 7)
        {
            timer = 0;
            for (int i = 0; i < 5; i++)
            {
                SpawnKid();
            }
        }
    }

    void SpawnKid()
    {
        randomX = Random.Range(transform.position.x-2,transform.position.x + 2);
        randomY = Random.Range(transform.position.y-2,transform.position.y + 2);
        whereToSpawn = new Vector2(randomX, randomY);
        int random = Random.Range(0, kids.Length);
        GameObject Kid = Instantiate(kids[random], whereToSpawn, Quaternion.identity);
    }
}
