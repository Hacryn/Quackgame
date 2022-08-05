using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpItem : MonoBehaviour
{
    public string objectName;
    public string description;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (OnPickUp(collision.gameObject)) Destroy(gameObject);
        }
    }

    public abstract bool OnPickUp(GameObject player);
}
