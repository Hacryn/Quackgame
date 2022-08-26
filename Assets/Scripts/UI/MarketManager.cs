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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CloseInterface()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void BuyPotion()
    {
        if(player.GetComponent<ResourceTracker>().Value >= 25)
        {
            HealthPotion potion = new()
            {
                healingAmount = 25
            };
            potion.Use(player);
        }
    }
}