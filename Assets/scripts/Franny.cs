using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Franny : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;
    //when the player gets near Franny, the nearest object is stored in a variable on the PlayerController script

    public override void Interact()
    {
        //Debug.Log("interacted!");

        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {

        if (playercontroller.inventory.CheckForFishItems())
        {
            dialogueText = franny_dialogue.Instance.Franny_Asks_for_Fish;
        }

        if ((franny_dialogue.Instance.IncrementDialogue == 0))
        {
            dialogue.DisplayNextParagraph(dialogueText);

        }
    }
}
