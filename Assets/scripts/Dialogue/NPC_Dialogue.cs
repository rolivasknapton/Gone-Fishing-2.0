using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public int IncrementDialogue = 0;


    public void IncrementDialogueInt()
    {

        IncrementDialogue += 1;
    }
    public void IncrementDialogueIntTo(int i)
    {
        IncrementDialogue = i;
    }


}
