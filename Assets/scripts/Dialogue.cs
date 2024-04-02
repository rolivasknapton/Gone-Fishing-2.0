using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed= 10f;

    [SerializeField]  private GameObject yes_no;
    

    public PlayerController playercontroller;

    private Queue<string> paragraphs = new Queue<string>();

    private bool conversationEnded;

    private bool convoInprogress;

    private bool isTyping;

    private bool progressInResponse;

    private string p;
    private bool question;
    private Coroutine typeDialogueCoroutine;
    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1F;


    private DialogueText currentlyDisplayedText;
    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //if nothing in que
        if(paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //start convo
                StartConversation(dialogueText);
                
            }

            else if (conversationEnded && !isTyping)
            {
                DialogueMethod(currentlyDisplayedText);

                //end convo
                EndConversation();
                
                return;
            }
        }

        //if there is something in the queue
        if (!isTyping)
        {
            if (yes_no.activeSelf)
            {
                if (yes_no.GetComponent<Select_YesorNo>().YesSelected() == false)
                {
                    //clear the queue
                    paragraphs.Clear();
                    StartConversation(dialogueText.chainedTexttwo);
                }
            }


            p = paragraphs.Dequeue();

            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
            if (yes_no.activeSelf)
            {
                yes_no.SetActive(false);
            }
        }

        //conversation is being type=d out
        else
        {
            FinishParagraphEarly();
        }
        

        //update our conversation text
        //NPCDialogueText.text = p;

        if (paragraphs.Count == 0)
        {
            conversationEnded = true;
        }
        if (question && conversationEnded)
        {
            //Debug.Log("gay");
            yes_no.gameObject.SetActive(true);
        }

        
        if ((question && conversationEnded ) && dialogueText.chainedText != null)
        {
            
            //reutrn bool to false
            conversationEnded = false;

            StartConversation(dialogueText.chainedText);
            
        }



    }

    private void StartConversation(DialogueText dialogueText)
    {
        //update current text
        currentlyDisplayedText = dialogueText;

        //notify npc
        convoInprogress = true;

        if (dialogueText.questionAsked)
        {
            question = true;
        }
        else
        {
            question = false;
        }
        //notify the player
        playercontroller.DialogueStarted();

        //activate gameObject
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        //update the speaker name
        NPCNameText.text = dialogueText.speakerName;

        //add dialogue text to the queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }

    }
    private void EndConversation()
    {
        //clear the queue
        paragraphs.Clear();

        //notify the player the convo is over
        playercontroller.DialogueEnded();

        //reutrn bool to false
        conversationEnded = false;

        ////return response bool to false
        //progressInResponse = false;

        //notifyother scrupts
        convoInprogress = false;

        //deactivate this gameobject
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        
    }

    

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        NPCDialogueText.text = "";

        string originalText = p;
        string displayedText = "";
        int alphaIndex = 0;

        foreach (char c in p.ToCharArray())
        {
            alphaIndex++;
            NPCDialogueText.text = originalText;

            displayedText = NPCDialogueText.text.Insert(alphaIndex, HTML_ALPHA);
            NPCDialogueText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }
    private void FinishParagraphEarly()
    {
        //stop coroutine
        StopCoroutine(typeDialogueCoroutine);
        //finish displaying text
        NPCDialogueText.text = p;
        //update isTyping bool
        isTyping = false;
    }
    public bool CheckIfConvoEnded()
    {
        if (convoInprogress)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void DialogueMethod(DialogueText dialogueText)
    {

        if (dialogueText.name == "happy")
        {
            //this is a mess of a line of code
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().inventory.RemoveItem(GameObject.FindWithTag("Player").GetComponent<PlayerController>().inventory.GetFirstFishItem());
            Debug.Log("take Fish!");
        }
    }
}

