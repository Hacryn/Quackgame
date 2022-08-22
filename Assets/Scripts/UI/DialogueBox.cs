using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class DialogueBox : MonoBehaviour
{
    private TextMeshProUGUI textScript;

    private void Start()
    {
        textScript = GetComponentInChildren<TextMeshProUGUI>(true);
    }
    public void DisplayDialogue(Dialogue dialogue)
    {
        if (dialogue != null)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(true);
            }

            textScript.text = dialogue.content;
        } else
        {
            Debug.Log("Dialogue " + dialogue.ID + "not found.");
        }
        
    }

    public void HideDialogue()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }

        textScript.text = "";
    }
}
