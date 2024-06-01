using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Screen_Fade : MonoBehaviour
{
    public static Black_Screen_Fade Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

}
