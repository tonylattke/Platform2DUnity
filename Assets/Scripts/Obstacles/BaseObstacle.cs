using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    [SerializeField]
    private int DamagePoints = 1;
    
    [SerializeField]
    bool canDamage = true;
    
    [SerializeField]
    bool canScale = true;
    
    [SerializeField]
    bool canMove = true;
    
    [SerializeField]
    bool canRotate = false;
    
    [SerializeField]
    float ScaleSpeed = 2;
    
    [SerializeField]
    float MoveSpeed = 2;
    
    [SerializeField]
    float RotateSpeed = 2;
    
    [SerializeField]
    public Vector3 ScaleDirection = new Vector3(0, 1, 0);

    [SerializeField]
    public Vector3 LocationDirection = new Vector3(1, 0, 0);
    
    [SerializeField]
    public Vector3 RotateDirection = new Vector3(1, 0, 0);
    
    private float transformTimer = 0;
    private float Interval = 2;
    
    public bool consumedPoints = false;
    
    [SerializeField]
    public int Points = 1;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        transformTimer += Time.deltaTime;
        if (transformTimer >= Interval)
        {
            ScaleDirection *= -1;
            LocationDirection *= -1;
            RotateDirection *= -1;
            transformTimer = 0;
        }

        UpdateScale();
        UpdateLocation();
        UpdateRotation();
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

    private void UpdateScale()
    {
         if (!canScale)
             return;
         
         gameObject.transform.localScale  += ScaleDirection * (ScaleSpeed * Time.deltaTime);
    }
    
    private void UpdateLocation()
    {
        if (!canMove)
            return;
        
        transform.Translate(LocationDirection * (Time.deltaTime * MoveSpeed));
    }
    
    private void UpdateRotation()
    {
        if (!canRotate)
            return;
        
        transform.Rotate(RotateDirection * (Time.deltaTime * RotateSpeed));
    }
}
