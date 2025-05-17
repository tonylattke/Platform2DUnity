using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance SingletonGameInstance;

    [SerializeField] 
    public int currentScore = 10;
    [SerializeField] 
    public float currentLifePoints = 10;
    [SerializeField] 
    public float maxLifePoints = 10;

    private void Awake()
    {
        if (SingletonGameInstance == null)
        {
            SingletonGameInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
