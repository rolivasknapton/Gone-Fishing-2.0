using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaving_Ballroom : MonoBehaviour
{
    [SerializeField]
    private GameObject mainHall;
    [SerializeField]
    private GameObject ballroom;

    //bool isActivatable = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" /*&& isActivatable*/)
        {
            //deactivates the ballroom evironment
            ballroom.SetActive(false);
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
