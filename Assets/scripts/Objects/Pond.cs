using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour, IFishable
{
    public GameObject[] fishInPond;

   
    public void Fish()
    {
        
            GetRandomFish().GetComponent<FishMovement>().MoveTowardPlayer();
              
    }

    public GameObject GetRandomFish()
    {
        
        if (fishInPond.Length == 0)
        {
            Debug.LogWarning("The fishInPond list is empty!");
            return null;
        }

        int randomIndex = Random.Range(0, fishInPond.Length);
        return fishInPond[randomIndex];
    }
}
