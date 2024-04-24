using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg_Dialogue : NPC_Dialogue
{
    public static Greg_Dialogue Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }


    public DialogueText Greg_What_I_Say;
    public DialogueText Greg_Final_Warning;
    public DialogueText Greg_Still_Looking;
}
