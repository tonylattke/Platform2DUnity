using UnityEngine;

public class GameConstants : MonoBehaviour
{
    public static GameConstants Singleton;
    
    public string playerTag = "Player";
    public string groundTag = "Ground";
    public string obstacleTag = "Obstacle";
    public string finalScoreScreenName = "FinalScoreScreen";
    public string killZone = "KillZone";
    public string earnPoints = "EarnPoints";
    
    
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
