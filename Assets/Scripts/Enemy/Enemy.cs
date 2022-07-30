using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if (currentHealth <=0) Die();
    }

    void Die(){
        Debug.Log("Enemy Died");
        gameObject.SetActive(false);
        //destroy element after death
    }
}
