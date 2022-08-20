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
            } else {
                resourceValue = value;
            }
        }
        get => resourceValue;
    }

    public override bool HasLimit { get => true; }
    
    void Reset()
    {
        resourceName = "Health";
    }

    void OnValidate() 
    {
        resourceValue = resourceLimit;
    }

}
