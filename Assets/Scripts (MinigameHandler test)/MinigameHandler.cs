using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : MonoBehaviour
{
    public virtual void l_init(int level)
    {

    }

    public virtual void OnCompleted()
    {

    }

    public virtual void OnFailed()
    {

    }

    public virtual void l_unInit()
    {

    }
}

public enum MinigameID
{
    PickBoxes,
    SortStuff,
}
