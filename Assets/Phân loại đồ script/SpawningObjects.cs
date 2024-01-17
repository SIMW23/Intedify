using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public Transform spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        int numberOfObjects = objectPrefabs.Length;

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
                Random.Range(spawnArea.position.y - spawnArea.localScale.y / 2, spawnArea.position.y + spawnArea.localScale.y / 2)
            );

            GameObject spawnedObj = Instantiate(objectPrefabs[i], randomPosition, Quaternion.identity);
        }
    }
}
