using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Door_State : MonoBehaviour
{
    [SerializeField]
    private GameObject openDoubleDoors;
    [SerializeField]
    private GameObject shutDoubleDoors;
    private void Start()
    {
        if (Progression.StoryProgression == 0)
        {
            shutDoubleDoors.SetActive(true);
        }
        if (Progression.StoryProgression == 1)
        {
            openDoubleDoors.SetActive(true);
        }
    }
}
