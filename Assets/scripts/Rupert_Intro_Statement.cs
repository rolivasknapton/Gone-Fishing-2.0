using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rupert_Intro_Statement : MonoBehaviour
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private Dialogue dialogue;
    
    private PlayerController playerController;

    private void Awake()
    {
        
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
    }
    IEnumerator Start()
    {
        Image blackScreenColor = Black_Screen_Fade.Instance.GetComponent<Image>();
        Color color = blackScreenColor.color;

        float fadeDuration = 1f; // Duration of the fade in seconds
        float timer = 0f;

        // Gradually increase alpha to 0 over fadeDuration seconds
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            blackScreenColor.color = color;
            yield return null;
        }

        // Ensure alpha is exactly 0 at the end of the loop
        color.a = 0f;
        blackScreenColor.color = color;

        DisplayRupertIntro();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (playerController.currentlySpeaking)
            {
                
                DisplayRupertIntro();
                if (dialogue.CheckIfConvoEnded())
                {
                    this.gameObject.SetActive(false);
                }
            }
            
        }
        
    }
    private void DisplayRupertIntro()
    {
        Debug.Log("intro ping");
        dialogue.DisplayNextParagraph(dialogueText);
        
    }

}
