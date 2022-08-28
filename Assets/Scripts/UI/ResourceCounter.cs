using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    private CurrencyTracker resourceTracked;
    private TextMeshProUGUI text;
    public string resource;
    void Start()
    {
        foreach (CurrencyTracker tracker in GameObject.Find("Player").GetComponents<CurrencyTracker>())
        {
            if (tracker.Name.Equals(resource))
            {
                resourceTracked = tracker;
                break;
            }
        }
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(resource + "s: " + resourceTracked.Value);
    }
}
