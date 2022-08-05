using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContinuousTileScript : TileScript
{
    protected int startContinuousTilePosition;
    protected int lengthContinuousTile;

    public int StartingPosition
    {
        set { if (value > 0) startContinuousTilePosition = value; }
    }

    public int Length
    {
        set { if (value > 0) lengthContinuousTile = value; }
    }

    public override void Start()
    {
        base.Start();
        SpawnExtra();
    }

    public abstract void SpawnExtra();
}
