using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickUpItem
{
    public float healingAmount;

    public override void OnPickUp(GameObject player) 
    {
        player.GetComponent<PlayerCombat>().Health += healingAmount;
    }
}
