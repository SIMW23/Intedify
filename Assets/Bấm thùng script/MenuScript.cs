using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject winMenuUI;
    public XepThungManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<XepThungManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Win();
    }
    void Win()
    {
        if (manager.redBoxCollected == 2)
        {
            winMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void toSortingMinigame()
    {
        SceneManager.LoadScene("SortingStuff");
    }
}
