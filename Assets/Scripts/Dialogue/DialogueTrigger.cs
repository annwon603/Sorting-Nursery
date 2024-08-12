using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueManager>().StartDialouge(dialogue);
    }

    public void Start()
    {
        TriggerDialouge();
    }
}
