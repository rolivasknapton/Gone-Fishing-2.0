using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Progression 
{
    private static int storyProgression = 1;
    public static int StoryProgression 
    {
        get
        {
            return storyProgression;   
        }
        set
        {
            storyProgression = value;
        }
    }




}
