using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MarketManager : MonoBehaviour
{
    private GameObject MarketUI;
    private void Start()
    {
        MarketUI = GameObject.FindWithTag("Market");
    }

    public void CloseInterface()
    {
        MarketUI.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void BuyPotion()
    {
        HealthPotion potion = new()
        {
            healingAmount = 25
        };
        potion.Use(GameObject.FindGameObjectWithTag("Player"));
    }
}