using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MarketTrigger : OnPassageTrigger
{
    private GameObject MarketUI;

    private void Start()
    {
        activatorTag = "Player";
        MarketUI = GameObject.FindWithTag("Market");
    }

    public override void OnPassage(GameObject activator)
    {
        foreach(Component component in MarketUI.GetComponentsInChildren<Component>(true))
        {
            component.gameObject.SetActive(true);
        }
        Time.timeScale = 0;
    }
}
