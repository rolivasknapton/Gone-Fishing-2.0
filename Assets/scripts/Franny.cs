using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Franny : MonoBehaviour, IInteractable, ITalkable
{
    public PlayerController playercontroller;

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;
    //when the player gets near Franny, the nearest object is stored in a variable on the PlayerController script
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playercontroller.StoreNearestGameObject(this.gameObject);
            playercontroller.inventory.CheckForFishItems();
        }
    }
    //when the player is not longer near franny the nearby object is deleted (should implement functionality to only clear nearby object if that object is franny
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playercontroller.StoreNearestGameObject(null);
        }
    }

    public void Interact()
    {
        Debug.Log("interacted!");
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogue.DisplayNextParagraph(dialogueText);
    }
}
