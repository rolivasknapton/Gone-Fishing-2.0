using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : Door
{
    
    public override void Interact()
    {
        if (!playercontroller.inventory.CheckForItemOfType(Item.ItemType.Key))
        {
            Debug.Log("Don't have key");
        }
        else
        {
            Debug.Log("has the key!");
        }
    }
}
