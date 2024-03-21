using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;


    public override void Interact()
    {
        //Debug.Log("interacted!");
        Talk(dialogueText);
        if (dialogue.CheckIfConvoEnded())
        {
           this.GetComponent<GregMovement>().EndConversation();
        }
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogue.DisplayNextParagraph(dialogueText);
        this.GetComponent<GregMovement>().StartConversation();
        

        
    }


}
