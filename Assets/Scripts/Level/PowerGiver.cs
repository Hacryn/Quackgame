using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGiver : PickUpItem
{

    [SerializeField] private GameObject spell;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;

    public override bool OnPickUp(GameObject player) {
        CurrencyTracker coin = null;
        CurrencyTracker soul = null;

        foreach(CurrencyTracker currency in player.GetComponentsInParent<CurrencyTracker>()) {
            if (currency.Name == "Coin") {
                coin = currency;
            } else if (currency.Name == "Soul") {
                soul = currency;
            }
        }

        if (coin == null) { Debug.Log("Non sono riuscuto a prendere coin"); }
        if (soul == null) { Debug.Log("Non sono riuscuto a prendere soul");}

        if (coin != null && soul != null) {
            if (coin.Value >= 10 && soul.Value >= 1) {
                player.GetComponentInParent<AttackController>().skill1[0] = spell;
                portal.SetActive(true);
                dialogue1.SetActive(true);
                dialogue2.SetActive(false);
                coin.Value = 0;
                soul.Value = 0;
                return true;
            }
            Debug.Log("Valori non sufficienti");
        }

        return false;

    }
}
