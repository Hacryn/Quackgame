using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : OnPassageTrigger
{
    public bool oneshot;

    [Tooltip("A list of Dialogue IDs that will displayed, one after other.")]
    public List<string> ids;

    private DialogueBox DialogueBox;

    private void Start()
    {
        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBox>();
        activatorTag = "Player";
    }



    public override void OnPassage(GameObject activator)
    {
        foreach (string id in ids)
        {
            DialogueBox.DisplayDialogue(id);
        }

        if (oneshot)
            Destroy(gameObject);
    }
}
