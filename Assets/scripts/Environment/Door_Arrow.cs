using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Arrow : MonoBehaviour
{
    private SpriteRenderer spriterender;

    bool isActivatable = false;
    private void Awake()
    {
        spriterender = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActivatable)
        {
            spriterender.enabled = true;
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spriterender.enabled = false;
            isActivatable = true;
        }
    }
    
}
