using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;

    public Sprite FrankWithHand;
    public GameObject CameraPosition;
    public override void Interact()
    {
        Talk(dialogueText);
        playercontroller.SetCameraPosition(CameraPosition);

    }

    public void Talk(DialogueText dialogueText)
    {
        if (Frank_Dialogue.Instance.IncrementDialogue == 1)
        {
            if (playercontroller.inventory.CheckForItemOfType(Item.ItemType.Hand))
            {
                dialogueText = Frank_Dialogue.Instance.Frank_Requests_Hand;
            }
            else
            {
                dialogueText = Frank_Dialogue.Instance.Frank_Advises_Digging;

            }
        }
        if (Frank_Dialogue.Instance.IncrementDialogue == 2)
        {
            dialogueText = Frank_Dialogue.Instance.Frank_Keys;
        }
        if (Frank_Dialogue.Instance.IncrementDialogue == 3)
        {
            dialogueText = Frank_Dialogue.Instance.Frank_Loop_After_Hand;
        }
        if (Frank_Dialogue.Instance.IncrementDialogue == 10)
        {
            dialogueText = Frank_Dialogue.Instance.Frank_You_Have_Keys;
        }
        dialogue.DisplayNextParagraph(dialogueText);
    }
    public void GiveHand()
    {
        SpriteRenderer spriteRenderer;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite =  FrankWithHand;
        
    }


}
