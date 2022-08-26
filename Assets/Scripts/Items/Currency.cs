using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : PickUpItem
{

    [SerializeField] private string currencyName;
    [SerializeField] private int currencyValue;

   public override bool OnPickUp(GameObject player)
   {
        foreach (CurrencyTracker component 
        in player.GetComponentsInParent<CurrencyTracker>()) {
            if (component.Name == currencyName) {
                component.Value += currencyValue;
                return true;
            }
        }
        return false;
    }
}
