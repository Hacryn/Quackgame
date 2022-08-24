using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickUpItem
{
    public float healingAmount;

    public override bool OnPickUp(GameObject player) 
    {
        if (player.GetComponentInParent<HealthTracker>().HasMaxValue && healingAmount > 0) return false;
        player.GetComponentInParent<HealthTracker>().Value += healingAmount;
        return true;
    }
}
