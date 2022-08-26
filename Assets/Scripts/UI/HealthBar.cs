using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    HealthTracker health;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthTracker>();
    }

    void Update()
    {
        GetComponent<Image>().fillAmount = health.Value / health.Limit;
    }
}
