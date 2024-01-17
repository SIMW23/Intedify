using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    private SpriteRenderer m_Renderer;
    private Color original;
    private Color highlight = Color.gray;
    public PickingBoxes pickUpMinigame;
    private void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        original = m_Renderer.material.color;
    }

    private void Update()
    {
        
    }
    private void OnMouseOver()
    {
        m_Renderer.material.color = highlight;

        if (Input.GetMouseButtonDown(0) && pickUpMinigame.dadSequence == true)
        {
            if (gameObject.tag == "BlueBox")
            {
                pickUpMinigame.blueBoxCollected++;
                Debug.Log(pickUpMinigame.blueBoxCollected);
                Destroy(this.gameObject);
            }
            else
            {
                //de thoai sai hop
            }
        }

        else if (Input.GetMouseButtonDown(0) && pickUpMinigame.momSequence == true)
        {
            if (gameObject.tag == "RedBox")
            {
                pickUpMinigame.redBoxCollected++;
                Debug.Log(pickUpMinigame.redBoxCollected);
                Destroy(this.gameObject);
            }
            else
            {
                //de thoai sai hop
            }
        }

    }
    private void OnMouseExit()
    {
        m_Renderer.material.color = original;
    }
}
