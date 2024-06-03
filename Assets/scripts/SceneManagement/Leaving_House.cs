using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaving_House : MonoBehaviour
{
    [SerializeField]
    private ChangeScene changeScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Progression.StoryProgression == 0 )
        {
            changeScene.MoveToScene("outside");
        }
    }    
}
