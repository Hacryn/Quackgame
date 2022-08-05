using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string text;
    public int duration;
    private DialogueBox DialogueBox;
    private void Start()
    {
        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBox>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogueBox.DisplayDialogue(text, duration);
        }
    }
}
