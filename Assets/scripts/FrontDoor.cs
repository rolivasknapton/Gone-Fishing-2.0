using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : Door
{
    [SerializeField] private Dialogue dialogue;
    public override void Interact()
    {
        if (!playercontroller.inventory.CheckForItemOfType(Item.ItemType.Key))
        {
            Debug.Log("Don't have key");
            dialogue.DisplayNextParagraph(Rupert_Dialogue.Instance.Rupert_Door_Locked);
        }
        else
        {
            Debug.Log("has the key!");

        }
    }
}
