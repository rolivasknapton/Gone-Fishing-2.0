using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair_Collision : MonoBehaviour, IInteractable
{
    [SerializeField] private Dialogue dialogue;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            dialogue.DisplayNextParagraph(Rupert_Dialogue.Instance.Rupert_Refuses_Stairs);
        }

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
    public void Interact()
    {
        dialogue.DisplayNextParagraph(Rupert_Dialogue.Instance.Rupert_Refuses_Stairs);
    }
}
