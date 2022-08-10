using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    private TextMeshProUGUI textScript;
    private DialogueManager dialogueManager;

    private void Start()
    {
        textScript = GetComponentInChildren<TextMeshProUGUI>(true);
        dialogueManager = new DialogueManager();
    }
    public void DisplayDialogue(string ID)
    {
        Dialogue dialogue = dialogueManager.DialogueList.Find(dialogue => dialogue.ID == ID);

        if (dialogue != null)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(true);
            }

            textScript.text = dialogue.content;

            Invoke(nameof(HideDialogue), dialogue.duration);

        } else
        {
            Debug.Log("Dialogue " + ID + "not found.");
        }
        
    }

    void HideDialogue()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }

        textScript.text = "";
    }
}
