using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArea : MonoBehaviour
{
    public SortingDialogue dialogueManager;
    public int numberOfBalls;
    // Start is called before the first frame update
    void Start()
    {
        numberOfBalls = 0;
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<SortingDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected collision");
        if (collision.tag == "Ball")
        {
            numberOfBalls++;
            DraggableObjects draggableObjects = collision.GetComponent<DraggableObjects>();
            dialogueManager.PlayerMadeCorrectChoice();
            if (draggableObjects != null)
            {
                draggableObjects.isDraggable = false;
                draggableObjects.isDragging = false;
                Debug.Log(numberOfBalls);
            }
        }
        else if (collision.tag == "Figure")
        {
            DraggableObjects draggableObject = collision.GetComponent<DraggableObjects>();
            StartCoroutine(LerpBackToOriginalLocation(draggableObject.gameObject, draggableObject.originalPosition));
            dialogueManager.PlayerMadeWrongChoice();
        }
    }
    IEnumerator LerpBackToOriginalLocation(GameObject obj, Vector2 originalPosition)
    {
        float lerpDuration = 0.7f;
        float elapsedTime = 0f;
        Vector2 startPosition = obj.transform.position;

        while (elapsedTime < lerpDuration)
        {
            obj.transform.position = Vector2.Lerp(startPosition, originalPosition, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = originalPosition;
    }
    ///test commit
}
