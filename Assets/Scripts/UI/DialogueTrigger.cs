using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class DialogueTrigger : OnPassageTrigger
{
    public bool oneshot;

    [Tooltip("A list of Dialogue IDs that will displayed, one after other.")]
    public List<string> ids;

    public string DialogueFile;
    
    private DialogueManager dialogueManager;
    private DialogueBox DialogueBox;

    private bool shooted;

    private void Start()
    {
        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBox>();
        activatorTag = "Player";
        dialogueManager = new DialogueManager(DialogueFile);
        shooted = false;
    }



    public override void OnPassage(GameObject activator)
    {
        if (!shooted) {
            shooted = true;
            StartCoroutine(StartDialogue());
        }   
    }

    public IEnumerator StartDialogue()
    {
        foreach (string id in ids)
        {
            Dialogue dialogue = dialogueManager.DialogueList.Find(dialogue => dialogue.ID == id);

            DialogueBox.DisplayDialogue(dialogue);
            yield return new WaitForSeconds(dialogue.duration);
            DialogueBox.HideDialogue();
        }
        if (oneshot) { Destroy(gameObject); }
        shooted = false;
    }
}
