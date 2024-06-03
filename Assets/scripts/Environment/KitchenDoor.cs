using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : Door
{
    [SerializeField]
    private Dialogue dialogue;
    public override void Interact()
    {
        if (Progression.StoryProgression == 0)
        {
            dialogue.DisplayNextParagraph(Rupert_Dialogue.Instance.Rupert_Interior_Door_Locked);
        }
    }

}
