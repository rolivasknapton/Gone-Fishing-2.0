using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class franny_dialogue : MonoBehaviour
{
    public static franny_dialogue Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public DialogueText Franny_Asks_for_Fish;
}
