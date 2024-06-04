using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaving_Room : MonoBehaviour
{
    [SerializeField]
    private GameObject mainHall;
    [SerializeField]
    private GameObject room;

    //bool isActivatable = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" /*&& isActivatable*/)
        {
            //deactivates the ballroom evironment
            room.SetActive(false);
            //this sets this gameobject inactive as well so it is best to leave this to the end of the logic
            mainHall.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            //isActivatable = true;
        }
    }
}
