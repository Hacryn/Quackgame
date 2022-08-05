using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{
    public string objectName;
    public string description;
    public float healingAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();

            if (playerCombat.health != playerCombat.maxHealth)
            {
                playerCombat.health = Mathf.Min(playerCombat.maxHealth, playerCombat.health + healingAmount);
                Destroy(gameObject);
            }
        }
    }
}
