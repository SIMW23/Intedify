using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingBoxes : MinigameHandler
{
    public GameObject redBoxPrefab;
    public GameObject blueBoxPrefab;
    public GameObject purpleBoxPrefab;
    public GameObject background;
    public Transform[] spawnPoints;
    Vector3 backgroundPos;
    public int blueBoxCollected;
    public int redBoxCollected;
    int redBoxSpawned;
    int blueBoxSpawned;
    int purpleBoxSpawned;
    public bool dadSequence = true;
    public bool momSequence = false;
   
   
    public override void l_init(int level)
    {
        Debug.Log("loading minigame");
        Debug.Log(level);
        backgroundPos = new Vector3(0f, 0f, 0f);
        Instantiate(background);
        background.transform.position = backgroundPos;
        CreateSpawnPoints();
        SpawnBoxes();
    }

    public void OnCompleted()  
    {
        base.OnCompleted();
    }

    public void OnFailed()
    {
        base.OnFailed();
    }
    void Update()
    {
        changeSequence();
    }
    void changeSequence()
    {
        if (blueBoxCollected == 2)
        {
            dadSequence = false;
            momSequence = true;
            Debug.Log("changed sequence");
        }
    }
    void CreateSpawnPoints()
    {
        spawnPoints = new Transform[5];
        float spacing = 3.5f;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject spawnPointObject = new GameObject("SpawnPoint " + i);
            spawnPointObject.transform.position = new Vector3(i * spacing, -3f, 0f);
            spawnPoints[i] = spawnPointObject.transform;
        }
    }

    void SpawnBoxes()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject spawningBoxes = GetRandomBox();
            if(spawningBoxes != null)
            {
                Instantiate(spawningBoxes, spawnPoints[i].position, Quaternion.identity);
                Debug.Log("Spawning boxes at: " + spawningBoxes.transform.position);
            }

        }
    }
    private GameObject GetRandomBox()
    {
        GameObject[] chooseBoxToSpawn = new GameObject[]
        {
            (redBoxSpawned < 2) ? redBoxPrefab : null,
            (blueBoxSpawned < 2) ? blueBoxPrefab : null,
            (purpleBoxSpawned < 1) ? purpleBoxPrefab : null
        };

        List<GameObject> validBoxes = new List<GameObject>();
        foreach (var box in chooseBoxToSpawn)
        {
            if (box != null)
            {
                validBoxes.Add(box);
            }
        }

        if (validBoxes.Count == 0)
        {
            return null; //spawn het hop ra roi
        }

        GameObject boxToSpawn = validBoxes[Random.Range(0, validBoxes.Count)];

        if (boxToSpawn == redBoxPrefab)
        {
            redBoxSpawned++;
        }
        else if (boxToSpawn == blueBoxPrefab)
        {
            blueBoxSpawned++;
        }
        else if(boxToSpawn == purpleBoxPrefab)
        {
            purpleBoxSpawned++;
        }

        return boxToSpawn;
    }
   
    private void Start()
    {
  
    }

}

