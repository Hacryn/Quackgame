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
    
    public List<GameObject> enemySpawnPoints;
    public List<GameObject> enemyList;
    public int numberOfEnemySpawns;

    public List<GameObject> itemSpawnPoints;
    public List<GameObject> itemList;
    public int numberOfItemSpawns;

    protected System.Random rng;

    public virtual void Start()
    {
        rng = new System.Random();
        SpawnEnemies();
        SpawnItems();
        SpawnExtra();
    }

    public virtual void SpawnEnemies() 
    {
        int spawnPoint;
        int enemy;

        if (enemySpawnPoints.Count == 0) return;
        if (enemyList.Count == 0) return;
        
        for (int i = 0; i < numberOfEnemySpawns; i++) {
            spawnPoint = rng.Next(0, enemySpawnPoints.Count);
            enemy = rng.Next(0, enemyList.Count);
            Instantiate(enemyList[enemy], enemySpawnPoints[spawnPoint].transform.position, Quaternion.identity);
            enemySpawnPoints.RemoveAt(spawnPoint);
        }
    }

    public virtual void SpawnItems()
    {
        int spawnPoint;
        int item;
        
        if (itemSpawnPoints.Count == 0) return;
        if (itemList.Count == 0) return;
        
        for (int i = 0; i < numberOfEnemySpawns; i++) {
            spawnPoint = rng.Next(0, itemSpawnPoints.Count);
            item = rng.Next(0, itemList.Count);
            Instantiate(itemList[item], itemSpawnPoints[spawnPoint].transform.position, Quaternion.identity);
            itemSpawnPoints.RemoveAt(spawnPoint);
        }
    }

    public virtual void SpawnExtra() {}

}
