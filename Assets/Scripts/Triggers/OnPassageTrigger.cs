using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnPassageTrigger : MonoBehaviour
{
    protected GameObject activator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == activator)
        {
            OnPassage(collision.gameObject);
        }
    }

    public abstract void OnPassage(GameObject activator);
}
