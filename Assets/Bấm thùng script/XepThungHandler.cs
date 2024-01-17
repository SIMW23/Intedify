using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XepThungHandler : MonoBehaviour
{
    private SpriteRenderer m_Renderer;
    private Color original;
    private Color highlight = Color.gray;
    public XepThungManager manager;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        original = m_Renderer.material.color;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<XepThungManager>();
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        m_Renderer.material.color = highlight;

        if (Input.GetMouseButtonDown(0) && manager.dadSequence == true)
        {
            if (gameObject.tag == "BlueBox")
            {
                manager.blueBoxCollected++;
                Destroy(this.gameObject);
                dialogueManager.PlayerMadeCorrectChoice();
                Debug.Log("Dad section right");
            }
            else
            {
                //de thoai sai hop
                dialogueManager.PlayerMadeWrongChoice();
                Debug.Log("Dad section wrong");
            }
        }

        else if (Input.GetMouseButtonDown(0) && manager.momSequence == true)
        {
            if (gameObject.tag == "RedBox")
            {
                manager.redBoxCollected++;
                Destroy(this.gameObject);
                dialogueManager.PlayerMadeCorrectChoice();
                Debug.Log("Mom section right");
            }
            else
            {
                //de thoai sai hop
                dialogueManager.PlayerMadeWrongChoice();
                Debug.Log("Mom section wrong");
            }
        }

    }
    private void OnMouseExit()
    {
        m_Renderer.material.color = original;
    }
}
