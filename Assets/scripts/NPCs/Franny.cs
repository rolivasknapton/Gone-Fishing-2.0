using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Franny : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;

    public GameObject CameraPosition;
    //when the player gets near Franny, the nearest object is stored in a variable on the PlayerController script

    public override void Interact()
    {
        Talk(dialogueText);
        playercontroller.SetCameraPosition(CameraPosition);
        
    }

    public void Talk(DialogueText dialogueText)
    {
        if (franny_dialogue.Instance.IncrementDialogue == 1)
        {
            if (playercontroller.inventory.CheckForItemOfType(Item.ItemType.Fish))
            {
                dialogueText = franny_dialogue.Instance.Franny_Asks_for_Fish;
            }
            else
            {
                dialogueText = franny_dialogue.Instance.Franny_Come_Back;

            }
        }

        if (franny_dialogue.Instance.IncrementDialogue == 2)
        {
            dialogueText = franny_dialogue.Instance.Franny_Thank_You;
        }
        if(franny_dialogue.Instance.IncrementDialogue == 10)
        {
            dialogueText = franny_dialogue.Instance.Franny_You_Have_Keys;
        }

        dialogue.DisplayNextParagraph(dialogueText);
    }
}
