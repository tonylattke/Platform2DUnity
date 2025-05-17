using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class GameCore : MonoBehaviour
{
    [FormerlySerializedAs("SpawnedObtacles")] [SerializeField] 
    private List<GameObject> spawnedObtacles = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        int amountOfSpawnedObtacles = spawnedObtacles.Count;
        if (amountOfSpawnedObtacles > 2)
        {
            GameObject obtacle = spawnedObtacles[0];
            spawnedObtacles.RemoveAt(0);
            Destroy(obtacle);
        }
    }

    public void AddObstacle(GameObject obtacle)
    {
        spawnedObtacles.Add(obtacle);
    }
}
