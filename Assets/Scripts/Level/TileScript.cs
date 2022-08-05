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
        // Spawn enemies
        SpawnObjects(enemySpawnPoints, enemyList, numberOfEnemySpawns);
        // Spawn items
        SpawnObjects(itemSpawnPoints, itemList, numberOfItemSpawns);
        SpawnExtra();
    }

    public virtual void SpawnObjects(List<GameObject> spawnPoints, List<GameObject> objectList, int spawns) 
    {
        int spawnPoint;
        int obj;

        if (spawnPoints.Count == 0) return;
        if (objectList.Count == 0) return;
        
        for (int i = 0; i < spawns; i++) {
            spawnPoint = rng.Next(0, spawnPoints.Count);
            obj = rng.Next(0, objectList.Count);
            Instantiate(objectList[obj], spawnPoints[spawnPoint].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawnPoint);
        }
    }

    public virtual void SpawnExtra() {}

}
