using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XepThungManager : MonoBehaviour
{
    public int blueBoxCollected;
    public int redBoxCollected;
    public bool dadSequence = true;
    public bool momSequence = false;
    public bool win = false;
    public GameObject dad;
    DialogueManager dialogueManager;
    private SpriteRenderer m_Renderer;
    public Sprite momSprite;
    public Sprite dadSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = dad.GetComponent<SpriteRenderer>();
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSequence();
        ChangeSprite();
    }
    void ChangeSequence()
    {
        if(blueBoxCollected == 2)
        {
            dadSequence = false;
            momSequence = true;
            dialogueManager.DisplayDialogue(dialogueManager.initialDialogue);
        }
        if(redBoxCollected == 2 && blueBoxCollected == 2)
        {
            win = true;
            momSequence = false;
            
            dialogueManager.DisplayDialogue(dialogueManager.initialDialogue);
        }
    }
    void ChangeSprite()
    {
        if(dadSequence == true)
        {
            m_Renderer.sprite = dadSprite;
        }
        else if(momSequence == true)
        {
            m_Renderer.sprite = momSprite;
        }
    }
}
