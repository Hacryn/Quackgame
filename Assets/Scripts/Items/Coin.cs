using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickUpItem
{
    public override bool OnPickUp(GameObject player)
    {
        return true;
    }
}
