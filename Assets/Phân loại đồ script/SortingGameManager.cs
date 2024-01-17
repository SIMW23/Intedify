using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingGameManager : MonoBehaviour
{
    public BallArea ballArea;
    public FigureArea figureArea;
    public SortingDialogue dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        ballArea = GameObject.FindGameObjectWithTag("BallArea").GetComponent<BallArea>();
        figureArea = GameObject.FindGameObjectWithTag("FigureArea").GetComponent<FigureArea>();
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<SortingDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        Win();
    }

    void Win()
    {
        if (ballArea.numberOfBalls >= 4 && figureArea.numberOfFigures >= 4)
        {
            dialogueManager.dialogueIndex = 1;
            dialogueManager.DisplayDialogue(dialogueManager.initialDialogue);
        }
    }
}
