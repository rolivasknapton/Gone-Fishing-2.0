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
        if(Greg_Dialogue.Instance.IncrementDialogue == 1)
        {
            dialogueText = Greg_Dialogue.Instance.Greg_What_I_Say;
        }
        if(Greg_Dialogue.Instance.IncrementDialogue == 2)
        {
            dialogueText = Greg_Dialogue.Instance.Greg_Final_Warning;
        }
        if(Greg_Dialogue.Instance.IncrementDialogue == 3)
        {
            dialogueText = Greg_Dialogue.Instance.Greg_Still_Looking;
        }
        if(Greg_Dialogue.Instance.IncrementDialogue == 10)
        {
            dialogueText = Greg_Dialogue.Instance.Greg_Hey_Look_At_That;
        }




        dialogue.DisplayNextParagraph(dialogueText);

        gregMovement.StartConversation();
        
    }


}
