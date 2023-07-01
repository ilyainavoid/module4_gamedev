using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemys = new GameObject[5];
    public int maxEnemy = 5;
    public float timeSpawn = 5f;
    private float timer;
    public Tilemap tilemap;
    List<Vector3> unusedCoordinates;
    public bool spawnBoss;
    private bool bossSpawned;
    private int currentWave;
    public WaveManager waveManageer;
    private void Start()
    {
        unusedCoordinates = GetUnusedTileCoordinates();
        timer = timeSpawn;
        currentWave = waveManageer.currentWave;
    }

    private void Update()
    {
        currentWave = waveManageer.currentWave;
        
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeSpawn;
                if (transform.childCount < maxEnemy)
                {
                    if (spawnBoss)
                    {
                        Instantiate(enemys[4], unusedCoordinates[Random.Range(0, unusedCoordinates.Count)],
                            Quaternion.identity, transform);
                    }
                    else if (!spawnBoss)
                    {
                        int random = Random.Range(0, currentWave - 1);
                        Instantiate(enemys[random], unusedCoordinates[Random.Range(0, unusedCoordinates.Count)],
                            Quaternion.identity, transform);
                    }
                }
            }

    }

    private List<Vector3> GetUnusedTileCoordinates()
     {
         List<Vector3> unusedCoordinates = new List<Vector3>();

         BoundsInt bounds = tilemap.cellBounds;
         TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

         for (int x = bounds.xMin; x < bounds.xMax; x++)
         {
             for (int y = bounds.yMin; y < bounds.yMax; y++)
             {
                 Vector3Int tilePosition = new Vector3Int(x, y, 0);

                if (!tilemap.HasTile(tilePosition))
                {

                    continue;
                }

                 Vector3 worldPosition = tilemap.CellToWorld(tilePosition);

                 unusedCoordinates.Add(worldPosition);
             }
         }

         return unusedCoordinates;
     }

}
