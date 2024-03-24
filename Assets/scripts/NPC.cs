using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{

    public PlayerController playercontroller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playercontroller.StoreNearestGameObject(this.gameObject);
            
            
            //playercontroller.inventory.CheckForFishItems();
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
    public abstract void Interact();

    

    
}
