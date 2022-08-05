using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickUpItem
{
    public float healingAmount;

    public override bool OnPickUp(GameObject player) 
    {
        if (player.GetComponent<PlayerCombat>().HasMaxHealth && healingAmount > 0) return false;
        player.GetComponent<PlayerCombat>().Health += healingAmount;
        return true;
    }
}
