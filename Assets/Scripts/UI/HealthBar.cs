using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerCombat player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().fillAmount = player.health / player.maxHealth;
    }
}
