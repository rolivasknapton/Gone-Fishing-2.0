using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Franny : MonoBehaviour, IInteractable
{

    
    public PlayerController playercontroller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playercontroller.StoreNearestGameObject(this.gameObject);
            playercontroller.inventory.CheckForFishItems();
        }
    }
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
    }
}
