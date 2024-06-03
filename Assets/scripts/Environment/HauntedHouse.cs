using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject openDoubleDoors;
    [SerializeField]
    private GameObject shutDoubleDoors;
    // Start is called before the first frame update
    
    public void ShutDoors()
    {
        shutDoubleDoors.SetActive(true);
        openDoubleDoors.SetActive(false);
    }
}
