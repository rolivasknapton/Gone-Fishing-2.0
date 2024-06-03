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
            //Debug.Log("next to player");
            if(playercontroller.nearbyObject == null)
            {
                playercontroller.StoreNearestGameObject(this.gameObject);
            }
           
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playercontroller.nearbyObject == this.gameObject)
            {
                playercontroller.StoreNearestGameObject(null);
            }
            
        }
    }
    public abstract void Interact();

    

    
}