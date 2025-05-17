using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    [SerializeField]
    private int DamagePoints = 1;
    
    [SerializeField]
    bool canDamage = true;
    
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
        if (!canDamage)
            return;
        
        if (!collision.gameObject.tag.Equals(GameConstants.Singleton.playerTag))
            return;
        
        Player player = collision.gameObject.GetComponent<Player>();
        player.ReceiveDamage(gameObject, DamagePoints);
    }
}
