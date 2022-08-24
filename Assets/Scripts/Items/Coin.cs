using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickUpItem
{

    [SerializeField] private int coins;

   public override bool OnPickUp(GameObject player)
   {
        foreach (CurrencyTracker component 
        in player.GetComponentsInParent<CurrencyTracker>()) {
            if (component.Name == "Coin") {
                component.Value += coins;
                return true;
            }
        }
        return false;
    }
}
