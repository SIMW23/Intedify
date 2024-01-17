using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XepThungTam : MonoBehaviour
{
    public GameObject blueBoxPrefab;
    public GameObject redBoxPrefab;
    public GameObject purpleBoxPrefab;
    public Transform[] spawnPoints;
    public int maxBlueBoxes = 2;
    public int maxRedBoxes = 2;
    public int maxPurpleBoxes = 1;

    private List<GameObject> spawnedBoxes = new List<GameObject>();

    private void Start()
    {
        SpawnRandomBoxes();
    }

    private void SpawnRandomBoxes()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject boxToSpawn = GetRandomBoxPrefab();
            if (boxToSpawn != null)
            {
                GameObject spawnedBox = Instantiate(boxToSpawn, spawnPoints[i].position, Quaternion.identity);
                spawnedBoxes.Add(spawnedBox);
            }
        }
    }

    private GameObject GetRandomBoxPrefab()
    {
        List<GameObject> availableBoxPrefabs = new List<GameObject>();

        if (CountBoxesByType(blueBoxPrefab) < maxBlueBoxes)
        {
            availableBoxPrefabs.Add(blueBoxPrefab);
        }
        if (CountBoxesByType(redBoxPrefab) < maxRedBoxes)
        {
            availableBoxPrefabs.Add(redBoxPrefab);
        }
        if (CountBoxesByType(purpleBoxPrefab) < maxPurpleBoxes)
        {
            availableBoxPrefabs.Add(purpleBoxPrefab);
        }

        if (availableBoxPrefabs.Count == 0)
        {
            return null;
        }

        return availableBoxPrefabs[Random.Range(0, availableBoxPrefabs.Count)];
    }

    private int CountBoxesByType(GameObject boxPrefab)
    {
        int count = 0;
        foreach (GameObject spawnedBox in spawnedBoxes)
        {
            if (spawnedBox.CompareTag(boxPrefab.tag))
            {
                count++;
            }
        }
        return count;
    }
}
