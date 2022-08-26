using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTraitor : Demon
{
    protected virtual void Start()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }
    
    protected override void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack only when player is in sight
        if (PlayerInSight() && !health.HasMaxValue)
        {
            if (cooldownTimer >= attackCooldown)
            {
                //Attack();
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }

        // Patrolling if the player is not in sight
        if (patrolling != null)
        {
            patrolling.enabled = !PlayerInSight();
        }
    }

    protected override IEnumerator ShowDamageCoroutine(float time)
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(time);
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }
}
