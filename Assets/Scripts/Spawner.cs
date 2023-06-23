using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemys;
    public int maxEnemy = 5;
    public float timeSpawn = 5f;
    private float timer;
    public Tilemap tilemap;
    List<Vector3> unusedCoordinates;
    private int killCount;

    private void Start()
    {
        unusedCoordinates = GetUnusedTileCoordinates();
        timer = timeSpawn;
        killCount = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (transform.childCount < maxEnemy)
            {
                Instantiate(enemys[0], unusedCoordinates[Random.Range(0, unusedCoordinates.Count)], Quaternion.identity, transform);
            }
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;
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


        return unusedCoordinates;
    }

}
