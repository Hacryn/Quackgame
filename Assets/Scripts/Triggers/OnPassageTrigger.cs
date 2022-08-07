using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnPassageTrigger : MonoBehaviour
{
    protected string activatorTag;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(activatorTag) )
        {
            OnPassage(collision.gameObject);
        }
    }

    public abstract void OnPassage(GameObject activator);
}
