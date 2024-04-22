using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed = 10f;

    [SerializeField] private GameObject yes_no;


    private PlayerController playercontroller;

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

    private Inventory inventory;
    public DialogueText currentlyDisplayedText;

    
    private GameObject frank;
    
    private void OnEnable()
    {
        playercontroller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerController>().inventory;
        frank = GameObject.Find("frank");
    }
    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //stop the player
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;

        //if nothing in que
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //start convo
                StartConversation(dialogueText);

            }

            else if (conversationEnded && !isTyping)
            {
                //increment the Dialogue at the end of the convo
                //( we do it here because if we do it at the beginning it will happen on every paragraph of the dialogue)
                //while this only calls once at the end of the dialgue text SO
                IncrementDialogueMethod(currentlyDisplayedText);

                //give the keys to rupert 
                if (currentlyDisplayedText.name == "Frank_Has_Keys" || currentlyDisplayedText.name == "Franny_Has_Keys")
                {
                    playercontroller.inventory.AddItem(new Item { itemType = Item.ItemType.Key, amount = 1 });
                }


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

            //update the speaker name
            NPCNameText.text = currentlyDisplayedText.speakerName;

            //executed relevant code if on a relevant dialogue
            StartOfDialogueMethod();


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

        if (paragraphs.Count == 0)
        {
            conversationEnded = true;
        }
        if (question && conversationEnded)
        {
            //Debug.Log("gay");
            yes_no.gameObject.SetActive(true);
        }

        //at the end of this dialoguetext, start the first chained text if it is there.
        if (conversationEnded && currentlyDisplayedText.chainedText != null)
        {

            //reutrn bool to false
            conversationEnded = false;

            StartConversation(currentlyDisplayedText.chainedText);

        }//if the player has talked to all of the other villagers, then start the second chained text.
        else if (conversationEnded && currentlyDisplayedText.chainedTexttwo != null && Rupert_Dialogue.Instance.IncrementDialogue == 2)
        {
            StartConversation(currentlyDisplayedText.chainedTexttwo);
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
        

        //activate gameObject
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        //add dialogue text to the queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }

        //notify the player
        playercontroller.DialogueStarted();
    }
    private void EndConversation()
    {
        //clear the queue
        paragraphs.Clear();

        //notify the player the convo is over
        playercontroller.DialogueEnded();

        //reutrn bool to false
        conversationEnded = false;

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
    public void IncrementDialogueMethod(DialogueText dialogueText)
    {
        //franny dialogue methods
        if (dialogueText.incrementFrannyDialogue)
        {
            franny_dialogue.Instance.IncrementDialogueInt();

            if (dialogueText.incrementDialogueTo >= 0)
            {
                franny_dialogue.Instance.IncrementDialogueIntTo(dialogueText.incrementDialogueTo);
                
                //if the value of the above method is 10 then all dialgoues are set to 10 as well its a way of progressing the narrative along so all of the npcs are aware of the progression.
                SetAllNPCDialogue(dialogueText);

            }
        }

        //Frankdialogue methods
        if (dialogueText.incrementFrankDialogue)
        {
            Frank_Dialogue.Instance.IncrementDialogueInt();
            if (dialogueText.incrementDialogueTo >= 0)
            {
                Frank_Dialogue.Instance.IncrementDialogueIntTo(dialogueText.incrementDialogueTo);

                //if the value of the above method is 10 then all dialgoues are set to 10 as well its a way of progressing the narrative along so all of the npcs are aware of the progression.
                SetAllNPCDialogue(dialogueText);
            }
        }
        
    }
    public void StartOfDialogueMethod()
    {
        ////grabs the fish if on the correct dialogue
        if (currentlyDisplayedText.name == "happy")
        {
            inventory.RemoveItem(inventory.GetFirstItemOfType(Item.ItemType.Fish));

            Rupert_Dialogue.Instance.IncrementDialogueInt();
        }
        //grabs the hand if on the correct dialogue
        if (currentlyDisplayedText.name == "Frank_Happy")
        {
            inventory.RemoveItem(inventory.GetFirstItemOfType(Item.ItemType.Hand));
            Rupert_Dialogue.Instance.IncrementDialogueInt();
            //give frank hand
            frank.GetComponent<Frank>().GiveHand();

        }
        //give the player an item
        
    }
    private void SetAllNPCDialogue(DialogueText dialogueText)
    {
        if (dialogueText.incrementDialogueTo == 10)
        {
            franny_dialogue.Instance.IncrementDialogueIntTo(dialogueText.incrementDialogueTo);
            Frank_Dialogue.Instance.IncrementDialogueIntTo(dialogueText.incrementDialogueTo);
        }
    }

}

