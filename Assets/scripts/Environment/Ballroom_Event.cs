using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballroom_Event : MonoBehaviour
{
    [SerializeField]
    private HauntedHouse hauntedHouse;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hi");
            hauntedHouse.UpstairsSteps();
        }
    }
}
