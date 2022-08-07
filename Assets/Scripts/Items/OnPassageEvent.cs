using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPassageEvent : OnPassageTrigger
{
    public GameObject EventActivator;
    public UnityEvent Event;
    public bool oneShot;
    public override void OnPassage(GameObject activator)
    {
        Event.Invoke();
        if (oneShot)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        activator = EventActivator;
    }
}
