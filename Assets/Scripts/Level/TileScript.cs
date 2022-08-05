using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Params of the tile
    private int tileSize;
    private int tilePosition;

    public int Size 
    {
        set { if (value > 0) tileSize = value; }
    }

    public int Position 
    {
        set { if (value >= 0) tilePosition = value; }
    }
    
    public List<GameObject> spawnPoints;
    public List<GameObject> enemyList;
    public int numberOfSpawns;

    protected System.Random rng;

    public virtual void Start()
    {
        rng = new System.Random();
        SpawnEnemies();
    }

    public virtual void SpawnEnemies() 
    {
        int spawnPoint;
        int enemy;

        if (spawnPoints.Count == 0) return;
        if (enemyList.Count == 0) return;
        
        for (int i = 0; i < numberOfSpawns; i++) {
            spawnPoint = rng.Next(0, spawnPoints.Count);
            enemy = rng.Next(0, enemyList.Count);
            Instantiate(enemyList[enemy], spawnPoints[spawnPoint].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawnPoint);
        }
    }

}
