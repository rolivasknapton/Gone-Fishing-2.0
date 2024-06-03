using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked_Ballroom_Door : Door
{
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private GameObject mainHall;
    [SerializeField]
    private GameObject ballroom;
    public override void Interact()
    {
        if (Progression.StoryProgression == 0)
        {
            dialogue.DisplayNextParagraph(Rupert_Dialogue.Instance.Rupert_Interior_Door_Locked);
        }
        else
        {
            //clear's player's nearby obj
            playercontroller.StoreNearestGameObject(null);
            //activates the ballroom evironment
            ballroom.SetActive(true);
            //this sets this gameobject inactive as well so it is best to leave this to the end of the logic
            mainHall.SetActive(false);

        }
        

    }
}
