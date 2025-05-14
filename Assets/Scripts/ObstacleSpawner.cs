using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject obstaclePrefab;

    [SerializeField] float speed = 10;
    
    private float timer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            // TODO clean it after some seconds
            Instantiate(obstaclePrefab, gameObject.transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
