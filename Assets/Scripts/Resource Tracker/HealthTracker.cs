using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : ResourceTracker
{
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

    void Start()
    {
        resourceName = "Health";
        resourceValue = resourceLimit;
    }

    void KillEntity() 
    {
        Debug.Log(gameObject.name + " killed");
    }

}
