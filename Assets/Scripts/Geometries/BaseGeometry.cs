using UnityEngine;

[System.Serializable]
public class BaseGeometry
{
    [SerializeField]
    private GeometryType geomType;
    
    [SerializeField]
    public Sprite sprite;
    
    [SerializeField]
    public Sprite logo;
    
    [SerializeField] 
    public Color logoColor;

    private float _currentBoxScale = 0.5f;
    private float MinBoxScale = 0.25f;
    private float MaxBoxScale = 0.5f;
    private const float BoxSpeedRescale = 2;
    
    private const float MinBoxScaleOriginal = 0.25f;
    private const float MaxBoxScaleOriginal = 0.5f;

    [SerializeField] 
    private int jumpSpeed = 300;
    private const int jumpSpeedOriginal = 300;
    
    [SerializeField]
    private int _dashSpeed = 200;
    private const int DashSpeedOriginal = 200;

    public void Skill(Player player)
    {
        switch (geomType)
        {
            case global::GeometryType.Box:
                BoxSkill(player);
                break;
            case global::GeometryType.Circle:
                CircleSkill(player);
                break;
            case global::GeometryType.Triangle:
                TriangleSkill(player);
                break;
        }
    }
    
    public GeometryType GeometryType()
    {
        return geomType;
    }
    
    public void BoxSkill(Player player)
    {
        float temporaryNewScale = _currentBoxScale - BoxSpeedRescale * Time.deltaTime;
        if (temporaryNewScale < MinBoxScale)
        {
            return;
        }
        
        UpdateBoxScale(player, temporaryNewScale);
    }
    
    public void CircleSkill(Player player)
    {
        if (player.playerRigidBody2D.linearVelocity.magnitude > 1)
        {
            return;
        }
        
        player.playerRigidBody2D.AddForce(new Vector2(player.MovementDirection * _dashSpeed, 0));
    }
    
    public void TriangleSkill(Player player)
    {
        if (!player.isOnGround)
        {
            return;
        }
        
        player.playerRigidBody2D.AddForce(new Vector2(0, jumpSpeed));
        player.isOnGround = false;
    }
    
    public void RecoverBoxSize(Player player)
    {
        float temporaryNewScale = _currentBoxScale + BoxSpeedRescale * Time.deltaTime;
        if (temporaryNewScale > MaxBoxScale)
        {
            return;
        }
        
        UpdateBoxScale(player, temporaryNewScale);
    }

    private void UpdateBoxScale(Player player, float newScale)
    {
        _currentBoxScale = newScale;
        player.gameObject.transform.localScale = new Vector3(_currentBoxScale, _currentBoxScale, _currentBoxScale);
    }

    public void RecoverNormalSizeAllGeometries(Player player)
    {
        UpdateBoxScale(player, MaxBoxScale);
    }

    public void resetStats()
    {
        MinBoxScale = MinBoxScaleOriginal;
        MaxBoxScale = MaxBoxScaleOriginal;
        
        jumpSpeed = jumpSpeedOriginal;
        
        _dashSpeed = DashSpeedOriginal;
    }

    public void ApplyNewStats(PowerUp powerUp)
    {
        switch (powerUp.GeomeType)
        {
            case global::GeometryType.Box:
                MinBoxScale = powerUp.MinBoxScale;
                MaxBoxScale = powerUp.MaxBoxScale;
                break;
            case global::GeometryType.Circle:
                jumpSpeed = powerUp.jumpSpeed;
                break;
            case global::GeometryType.Triangle:
                _dashSpeed = powerUp.CircleDashSpeed;
                break;
        }
    }
}
