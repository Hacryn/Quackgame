using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpItem : OnPassageTrigger
{
    public string objectName;
    public string description;

    public override void OnPassage(GameObject activator)
    {
        if (OnPickUp(activator))
            Destroy(gameObject);
    }

    void Start()
    {
        activator = GameObject.FindWithTag("Player");
    }

    public abstract bool OnPickUp(GameObject player);
}
