using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Dialogue/New Dialogue Container")]
public class DialogueText : ScriptableObject
{
    public string speakerName;

    [TextArea(5, 10)]
    public string[] paragraphs;
    public bool questionAsked;
    public bool incrementFrannyDialogue;
    public bool incrementFrankDialogue;
    public bool incrementRupertDialogue;
    
    public DialogueText chainedText;
    public DialogueText chainedTexttwo;


    //change the currentlty speaking to npc's dialogue increment to a specifc numnber
    //change this value on the last dialogue text SO
    //that you wish to close out of and then play a specific SO after
    public int incrementDialogueTo =-1 ;
    //incrementDialogueby


}
