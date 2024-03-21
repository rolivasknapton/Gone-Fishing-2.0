using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;


    public override void Interact()
    {
        //Debug.Log("interacted!");
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogue.DisplayNextParagraph(dialogueText);
    }

    
}
