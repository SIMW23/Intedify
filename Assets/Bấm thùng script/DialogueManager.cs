using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject character;
    public TMP_Text dialogueText;
    public GameObject speechBubble;
    public string[] initialDialogue;
    public string[] wrongChoiceDialogue;
    public string[] correctChoiceDialogue;
    public string[] winDialogue;
    XepThungManager manager;

    private int dialogueIndex = 0;
    private bool playerMadeCorrectChoice = false;

    // Start is called before the first frame update
    void Start()
    {
        DisplayDialogue(initialDialogue);
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<XepThungManager>();


    }

    // Update is called once per frame
    void Update()
    {
       if(manager.dadSequence == true)
        {
            dialogueIndex = 0;
        }
       else if(manager.momSequence == true)
        {
            dialogueIndex = 1;
        }
        else if (manager.win == true)
        {
            dialogueIndex = 2;
        }
    }
    public void DisplayDialogue(string[] dialogueLines)
    {
        if (dialogueIndex >= dialogueLines.Length)
        {
            HideSpeechBubble();
            return;
        }

        string dialogue = dialogueLines[dialogueIndex];
        dialogueText.text = dialogue;
        ShowSpeechBubble();
    }
    private void ShowSpeechBubble()
    {
        speechBubble.SetActive(true);
    }
    private void HideSpeechBubble()
    {
        speechBubble.SetActive(false);
    }
    public void PlayerMadeCorrectChoice()
    {
        playerMadeCorrectChoice = true;
        DisplayDialogue(correctChoiceDialogue);
        dialogueIndex = 0;
        StartCoroutine(returnDialogue());
    }
    public void PlayerMadeWrongChoice()
    {
        playerMadeCorrectChoice = false;
        DisplayDialogue(wrongChoiceDialogue);
        dialogueIndex = 0;
        StartCoroutine(returnDialogue());
    }
    private void SwitchToInitialDialogue()
    {
        if(manager.dadSequence == true)
        {
            dialogueIndex = 0;
            //DisplayDialogue(initialDialogue);
        }
        else if(manager.momSequence == true)
        {
            dialogueIndex = 1;
            //DisplayDialogue(initialDialogue);
        }
        else if(manager.win == true)
        {
            dialogueIndex = 2;
        }
        DisplayDialogue(initialDialogue);
    }
    void UpdateInitialDialogue(string[] newInitialDialogue)
    {
        initialDialogue = newInitialDialogue;
    }
    IEnumerator returnDialogue()
    {
        yield return new WaitForSeconds(2);
        DisplayDialogue(initialDialogue);
    }
}
