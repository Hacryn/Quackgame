using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class MarketManager : MonoBehaviour
{
    private GameObject player;
    private CurrencyTracker coins;
    private CurrencyTracker souls;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (CurrencyTracker tracker in player.GetComponents<CurrencyTracker>())
        {
            if (tracker.Name.Equals("Coin"))
            {
                coins = tracker;
            }
            else if(tracker.Name.Equals("Soul"))
            {
                souls = tracker;
            }
        }
    }

    public void CloseInterface()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void BuyPotion()
    {
        if(coins.Value >= 25 )
        {
            HealthPotion potion = new()
            {
                healingAmount = 25
            };

            if(potion.Use(player))
                coins.Value -= 25;
        }
    }
}