using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObjects : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    public bool isDraggable = true;
    public Vector2 originalPosition;
    int numberOfBalls;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
    void OnMouseDown()
    {
        if (isDraggable)
        {
            
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            isDragging = false;

        }
    }
    void OnMouseUp()
    {
        isDragging = false;
    }
}
