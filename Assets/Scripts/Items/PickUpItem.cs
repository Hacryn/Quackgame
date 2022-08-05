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
            OnPickUp(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public abstract void OnPickUp(GameObject player);
}
