using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupert_Dialogue : NPC_Dialogue
{
    public static Rupert_Dialogue Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

}