using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class franny_dialogue : NPC_Dialogue
{
    public static franny_dialogue Instance { get; private set; }
    

    private void Awake()
    {
        Instance = this;
    }

    
    public DialogueText Franny_Asks_for_Fish;
    public DialogueText Franny_Come_Back;
    public DialogueText Franny_Thank_You;
    public DialogueText Franny_You_Have_Keys;

}
