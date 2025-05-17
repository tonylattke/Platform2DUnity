using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    string SceneNameToLoad;

    [SerializeField] 
    private int Points;
    
    [SerializeField]
    private GameCore _GameCoreRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(GameConstants.Singleton.playerTag))
        {
            GameInstance.Singleton.currentScore += Points;
            SceneManager.LoadScene(SceneNameToLoad);
        }
    }
}
