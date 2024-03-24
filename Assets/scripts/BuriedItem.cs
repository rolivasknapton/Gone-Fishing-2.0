using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuriedItem : MonoBehaviour, IInteractable, IDiggable
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().StoreNearestGameObject(this.gameObject);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().StoreNearestGameObject(null);
        }
    }
    public void Interact()
    {
        Dig();
    }

    public void Dig()
    {
        Debug.Log("Dig!");
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().inventory.AddItem(new Item { itemType = Item.ItemType.Hand, amount = 1 });

        GameObject.FindWithTag("Player").GetComponent<PlayerController>().StoreNearestGameObject(null);
        this.gameObject.SetActive(false);

    }
}
