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
    public abstract float Value { get; set; }
    public virtual float Limit { get => resourceLimit; set => resourceLimit = value; }

    public abstract bool HasLimit { get; }
    public bool HasMaxValue { get => (resourceValue >= resourceLimit) && HasLimit; }
    
}
