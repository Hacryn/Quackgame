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
    [SerializeField]
    private TextMeshProUGUI warningText;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private GameObject lifesteal;


    private void Start()
    {
        player = GameObject.Find("Player");
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
        warningText.SetText("");
        Time.timeScale = 1;
    }
    
    public void BuyPotion()
    {
        warningText.SetText("");
        if(coins.Value >= 25 )
        {
            HealthPotion potion = new()
            {
                healingAmount = 25
            };

            if (potion.Use(player))
            {
                coins.Value -= 25;
                warningText.SetText("Acquisto effettuato!");
            }
            else
            {
                warningText.SetText("Hai già abbastanza salute!");
            }
        } else
        {
            warningText.SetText("Non hai risorse a sufficienza!");
        }
    }

    public void BuyFireball()
    {
        warningText.SetText("");
        if (player.GetComponent<AttackController>().skill1[0] != null)
        {
            warningText.SetText("Conosci già questa spell!");
        }
        else
        if (souls.Value < 1 || coins.Value < 10)
        {
            warningText.SetText("Non hai risorse a sufficienza!");
        }
        else
        {
            player.GetComponent<AttackController>().skill1[0] = fireball;
            souls.Value -= 1;
            coins.Value -= 10;
            warningText.SetText("Acquisto effettuato!");
        }
    }

    public void BuyLifeSteal()
    {
        warningText.SetText("");
        if (player.GetComponent<AttackController>().skill2[0] != null)
        {
            warningText.SetText("Conosci già questa spell!");
        }
        else
        if (souls.Value < 2 || coins.Value < 20)
        {
            warningText.SetText("Non hai risorse a sufficienza!");
        }
        else
        {
            player.GetComponent<AttackController>().skill2[0] = lifesteal;
            souls.Value -= 2;
            coins.Value -= 20;
            warningText.SetText("Acquisto effettuato!");
        }
    }

    public void BuyGreatSword()
    {
        warningText.SetText("");
        if (player.GetComponent<AttackController>().Damage == 50)
        {
            warningText.SetText("Possiedi già questo item!");
        }
        else
        if (coins.Value < 50)
        {
            warningText.SetText("Non hai risorse a sufficienza!");
        }
        else
        {
            player.GetComponent<AttackController>().Damage = 50;
            coins.Value -= 50;
            warningText.SetText("Danno aumentato!");
        }
    }
}