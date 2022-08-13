using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTracker : ResourceTracker
{
    public override float Value
    {
        set
        {
            if (resourceValue < 0) {
                resourceValue = 0;
            } else {
                resourceValue = value;
            }
        }
        get => resourceValue;
    }

    public override bool HasLimit { get => false; }

}
