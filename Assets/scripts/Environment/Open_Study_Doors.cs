using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Study_Doors : MonoBehaviour
{
    [SerializeField]
    private HauntedHouse hauntedHouse;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("playerdetected");
            hauntedHouse.ShutDoors();
        }
    }
}
