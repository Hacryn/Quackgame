using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPassageEvent : OnPassageTrigger
{
    public string selectedTag;
    public UnityEvent Event;
    public bool oneShot;
    public override void OnPassage(GameObject activator)
    {
        Event.Invoke();
        if (oneShot)
            Destroy(gameObject);
    }

    void Start()
    {
        activatorTag = selectedTag;
    }
}
