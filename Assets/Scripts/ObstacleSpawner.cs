using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject obstaclePrefab;
    
    [SerializeField]
    public GameObject gameCore;

    [SerializeField] 
    private float speed = 10;
    
    [SerializeField] 
    private float timerRangeMin = 1f;
    
    [SerializeField] 
    private float timerRangeMax = 2f;

    private float _timeToWaitForNextObstacleSpawn = 2;
    
    private float _currentTime = 0f;

    private GameCore _gameCoreRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        TimerGenerator();

        _gameCoreRef = gameCore.GetComponent<GameCore>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdatePosition();
        SpawnObstacle();
    }
    
    private void TimerGenerator()
    {
        _timeToWaitForNextObstacleSpawn = Random.Range(timerRangeMin, timerRangeMax);
    }

    private void UpdatePosition()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }
    
    private void SpawnObstacle()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime < _timeToWaitForNextObstacleSpawn)
        {
            return;
        }
        
        GameObject newObstacle = Instantiate(obstaclePrefab, gameObject.transform.position, Quaternion.identity);
        _gameCoreRef.AddObstacle(newObstacle);
        
        TimerGenerator();
        _currentTime = 0f;
    }
}
