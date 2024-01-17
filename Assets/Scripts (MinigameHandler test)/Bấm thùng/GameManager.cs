using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // instance
    private static GameManager instance;

    // Active minigame
    private MinigameHandler currentMinigame;


    public int level;
    // Get the instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    // Set the current minigame
    public void SetMinigame(MinigameID minigameID, int level)
    {
       
        if ((int)minigameID >= 0 && (int)minigameID < m_Minigame.Length)
        {
            MinigameHandler Minigame = m_Minigame[(int)minigameID];
            if(Minigame != null)
            {
                Minigame.l_init(level);
            }
            else
            {
                Debug.LogWarning("Minigame not assigned");
            }
        }
        else
        {
            Debug.LogError("Invalid Minigame type: " + minigameID);
        }

        //currentMinigame = Instantiate(m_Minigame[(int)level]);
        //currentMinigame.l_init(level);
    }
    //private void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log(level);
    //    }
    //}

    //public void SwitchLevel(int level)
    //{
    //    if(currentMinigame != null)
    //    {
    //        currentMinigame.l_unInit();
    //        currentMinigame.l_init(level);
    //    }
    //}

    [Header("Minigame")]
    [SerializeField] private MinigameHandler[] m_Minigame;
    //aaaaaaa
}

