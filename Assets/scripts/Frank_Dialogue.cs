using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank_Dialogue : MonoBehaviour
{

    public static Frank_Dialogue Instance { get; private set; }
    public int IncrementDialogue = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementDialogueInt()
    {
        IncrementDialogue += 1;
    }


    public DialogueText Frank_Advises_Digging;
    public DialogueText Frank_Requests_Hand;
    public DialogueText Frank_Keys;


}
