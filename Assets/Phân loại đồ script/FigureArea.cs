using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureArea : MonoBehaviour
{
    public int numberOfFigures;
    public SortingDialogue dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        numberOfFigures = 0;
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<SortingDialogue>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected collision");
        if (collision.tag == "Figure")
        {
            numberOfFigures++;
            dialogueManager.PlayerMadeCorrectChoice();
            DraggableObjects draggableObjects = collision.GetComponent<DraggableObjects>();
            if (draggableObjects != null)
            {
                draggableObjects.isDraggable = false;
                draggableObjects.isDragging = false;
                Debug.Log(numberOfFigures);
            }
        }
        else if (collision.tag == "Ball")
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
}
