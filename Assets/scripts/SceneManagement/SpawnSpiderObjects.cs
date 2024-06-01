using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpiderObjects : MonoBehaviour
{

    public GameObject spidewebs;
    // Start is called before the first frame update
    void Start()
    {
        if(Progression.StoryProgression == 1)
        {
            spidewebs.SetActive(true);
        }
    }

    
}
