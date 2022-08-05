using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textScript;
    public void DisplayDialogue(string msg, int duration)
    {
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(true);
        }

        textScript.text = msg;

        Invoke(nameof(HideDialogue), duration);
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
