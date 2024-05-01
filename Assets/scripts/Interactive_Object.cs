using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive_Object : MonoBehaviour, IInteractable
{
    private PlayerController playerController;
    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("next to player");
            if (playerController.nearbyObject == null)
            {
                playerController.StoreNearestGameObject(this.gameObject);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerController.nearbyObject == this.gameObject)
            {
                playerController.StoreNearestGameObject(null);
            }

        }
    }
    public abstract void Interact();
    
}
