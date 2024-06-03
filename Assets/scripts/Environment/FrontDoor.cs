using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : Door
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField]
    private ChangeScene changeScene;
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
            Progression.StoryProgression = 1;
            changeScene.MoveToScene("Inside");
        }
    }
}
