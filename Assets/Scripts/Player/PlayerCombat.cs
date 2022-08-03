using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    

    public Transform attackPoint;
    public int baseAtkDamage = 50;

    
    public float attackRange = 0.5f;
    public float attackRate = 2f;

    private float nextAttackTime = 0;
    public LayerMask basicEnemyLayers;



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
        animator.SetTrigger("attack");

        //detectEnemiesInRange
//        Collider2D[] hitEnemies = Physics2D.overlapSquareAll(attackPoint.position, attckPoint.;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, basicEnemyLayers);

        //Damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(baseAtkDamage);
            Debug.Log("you hit " + enemy.name);
        }
    }    
}
