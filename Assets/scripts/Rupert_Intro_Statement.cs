using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupert_Intro_Statement : MonoBehaviour
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;
    private Rigidbody playerrb;

    private void Awake()
    {
        playerrb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        dialogue.DisplayNextParagraph(dialogueText);
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            dialogue.DisplayNextParagraph(dialogueText);
            playerrb.velocity = Vector3.zero; 
        }
    }
}
