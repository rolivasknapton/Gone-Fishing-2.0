using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class franny_dialogue : MonoBehaviour
{
    public static franny_dialogue Instance { get; private set; }
    public int IncrementDialogue = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementDialogueInt()
    {
        IncrementDialogue += 1;
    }
    public DialogueText Franny_Asks_for_Fish;
    public DialogueText Franny_Come_Back;
    public DialogueText Franny_Thank_You;

}
