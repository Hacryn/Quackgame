using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousTiles : MonoBehaviour
{
    public int maxTiles;
    public int Length { get => maxTiles; }
    public List<GameObject> startTiles;
    public List<GameObject> middleTiles;
    public List<GameObject> endTiles;
    
    private System.Random rng;
    private int tilesPlaced;

    public void SetUp() {
        rng = new System.Random();
        tilesPlaced = 0;
    }

    public bool Ended() {
        return tilesPlaced >= maxTiles;
    }

    public GameObject NextTile()
    {
        if (tilesPlaced == 0) {
            return GetTile(startTiles);
        } else if (tilesPlaced >= (maxTiles - 1)) {
            return GetTile(endTiles);
        } else {
            return GetTile(middleTiles);
        }
    }

    private GameObject GetTile(List<GameObject> tileList)
    {
        int tile = rng.Next(0, tileList.Count);
        tilesPlaced++;
        return tileList[tile];
    }

}
