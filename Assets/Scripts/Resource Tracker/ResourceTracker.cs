using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceTracker : MonoBehaviour
{
    [SerializeField]
    protected string resourceName;
    [SerializeField]
    protected float resourceValue;
    [SerializeField]
    protected float resourceLimit;
    
    public string Name { get => resourceName; }
    public virtual float Value { get => resourceValue; set => resourceValue = value; }
    public virtual float Limit { get => resourceLimit; set => resourceLimit = value; }

    public bool HasLimit { get => resourceLimit != 0; }
    public bool HasMaxValue { get => resourceValue >= resourceLimit; }
}
