using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Franny : NPC,  ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;
    //when the player gets near Franny, the nearest object is stored in a variable on the PlayerController script
   
    public override void Interact()
    {
        Debug.Log("interacted!");
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogue.DisplayNextParagraph(dialogueText);
    }
}
