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
        Debug.Log("Collider en collision");
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameInstance.SingletonGameInstance.currentScore += Points;
            SceneManager.LoadScene(SceneNameToLoad);
        }
    }
}
