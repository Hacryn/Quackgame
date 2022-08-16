using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : ResourceTracker
{
    private Animator anim;
    private bool dead; 

    public override float Value
    {
        set
        {
            if (value > resourceLimit) {
                resourceValue = resourceLimit;
            }
            else if (resourceValue < 0) {
                resourceValue = 0;
                KillEntity();
            } else {
                resourceValue = value;
            }
        }
        get => resourceValue;
    }

    public override bool HasLimit { get => true; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    void Reset()
    {
        resourceName = "Health";
    }

    void OnValidate() 
    {
        resourceValue = resourceLimit;
    }

    void TakeDamage(float _damage)
    {
        resourceValue = Mathf.Clamp(resourceValue - _damage, 0, resourceLimit);

        if(resourceValue > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                dead = true;
            }
        }
    }

    void KillEntity() 
    {
        Debug.Log(gameObject.name + " killed");
    }

}
