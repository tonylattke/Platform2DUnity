using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;
using TMPro;

public class GameCore : MonoBehaviour
{
    [SerializeField] 
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    [SerializeField] 
    public int acceptedAmountOfSpawnedObstacles = 10;
    
    [SerializeField] 
    public TextMeshProUGUI scoreUIText;
    
    [SerializeField]
    private HUDManager hudManager = new HUDManager();

    [SerializeField] 
    public GameObject playerRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //hudManager.HideInGameUI();
    }

    // Update is called once per frame
    private void Update()
    {
        int amountOfSpawnedObstacles = spawnedObstacles.Count;
        if (amountOfSpawnedObstacles > acceptedAmountOfSpawnedObstacles)
        {
            GameObject obstacle = spawnedObstacles[0];
            spawnedObstacles.RemoveAt(0);
            Destroy(obstacle);
        }

        scoreUIText.text = "Score: " + GameInstance.Singleton.currentScore;
    }

    public void AddObstacle(GameObject obtacle)
    {
        spawnedObstacles.Add(obtacle);
    }
}
