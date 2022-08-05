using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //public Animator animation;
    

    public Transform attackPoint;
    public int baseAtkDamage = 50;

    public float health = 100f;
    public float maxHealth = 100f;
    public float Health 
    {
        set
        {
            if (value > maxHealth) health = maxHealth;
            else if (value < 0) {
                health = 0;
                OnDeath();
            } else {
                health = value;
            }
        }
        get => health;
    }

    public float attackRange = 0.5f;
    public float attackRate = 2f;

    private float nextAttackTime = 0;
    public LayerMask basicEnemyLayers;

    void Start() {
        attackPoint = GameObject.Find("attackPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Z)) 
            {
                Attack();
                nextAttackTime=Time.time + 1f /attackRate;
            }
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint==null){
            return;
        }  
             
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Attack(){
        //play attack animation
        //animator.SetTrigger("Attack");

        //detectEnemiesInRange
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, basicEnemyLayers);

        //Damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(baseAtkDamage);
            Debug.Log("you hit " + enemy.name);
        }
    }    

    private void OnDeath() 
    {
        Debug.Log("Player died");
    }

}
