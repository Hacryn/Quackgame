using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{   
    public GameObject starterTile;
    public List<GameObject> tileList;
    public List<GameObject> endTiles;

    public List<GameObject> continuousTiles;
    public int continuousTilesChance;

    public int minTiles;
    public int maxTiles;
    public int tileSize;
    private int length;

    private System.Random rng;

    // Start is called before the first frame update
    void Start()
    {
        rng = new System.Random();
        GenerateLength();
        PlaceStarterTile();
        PlaceTiles();
        PlaceEndTile();
    }

    private void GenerateLength()
    {
        length = rng.Next(minTiles, maxTiles);
    }

    private void PlaceStarterTile()
    {
        CreateTile(starterTile, 0);
    }

    private void PlaceTiles()
    {
        int tile;
        int pos;
        
        pos = tileSize;
        while (pos < (length * tileSize)) {
            if ((rng.Next(0,100) < continuousTilesChance) 
                && (continuousTiles.Count > 0)
                && (continuousTiles != null)) {
                tile = rng.Next(0, continuousTiles.Count);
                pos = CreateContinuousTiles(continuousTiles[tile], pos);
                continuousTiles.RemoveAt(tile);

                if (pos >= (length * tileSize)) length = pos / tileSize;

            } else {
                tile = rng.Next(0, tileList.Count);
                CreateTile(tileList[tile], pos);
                pos += tileSize;
            }
        }
    }

    private void PlaceEndTile() 
    {
        int tile = rng.Next(0, endTiles.Count);
        CreateTile(endTiles[tile], length * tileSize);
    }

    private int CreateContinuousTiles(GameObject tilesObject, int pos) 
    {
        ContinuousTiles tileset = tilesObject.GetComponent<ContinuousTiles>();
        
        tileset.SetUp();
        while (!tileset.Ended()) {
            CreateTile(tileset.NextTile(), pos);
            pos += tileSize; 
        }
        return pos;
    }

    private void CreateTile(GameObject tile, int pos)
    {
        GameObject tileCreated;
        tileCreated = Instantiate(tile, new Vector3(pos, 0, 0), Quaternion.identity);
        tileCreated.transform.parent = gameObject.transform;
    }

}
