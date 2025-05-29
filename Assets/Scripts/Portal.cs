using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] 
    private int Points;
    
    [SerializeField] 
    private GameObject gameCore;
    
    private GameCore _gameCoreRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameCoreRef = gameCore.GetComponent<GameCore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals(GameConstants.Singleton.playerTag))
        {
            return;
        }
        
        GameInstance.Singleton.currentScore += Points;
        SceneManager.LoadScene(_gameCoreRef.GetNextSceneToLoadName());
    }
}
