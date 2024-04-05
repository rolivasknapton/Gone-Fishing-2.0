using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;

    private GregMovement gregMovement;
    private void Start()
    {
        gregMovement = this.GetComponent<GregMovement>();
    }
    public override void Interact()
    {
        if (gregMovement.isVisible)
        {
            //Debug.Log("interacted!");
            Talk(dialogueText);
            if (dialogue.CheckIfConvoEnded())
            {
                gregMovement.EndConversation();
            }
        }
        
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogue.DisplayNextParagraph(dialogueText);

        gregMovement.StartConversation();
        
    }


}
