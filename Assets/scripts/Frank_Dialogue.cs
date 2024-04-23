using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank_Dialogue : NPC_Dialogue
{

    public static Frank_Dialogue Instance { get; private set; }
    

    private void Awake()
    {
        Instance = this;
    }

    


    public DialogueText Frank_Advises_Digging;
    public DialogueText Frank_Requests_Hand;
    public DialogueText Frank_Keys;
    public DialogueText Frank_You_Have_Keys;
    public DialogueText Frank_Loop_After_Hand;


}
