using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    protected int Speed = 5;
    
	[SerializeField]
    protected Inventory MyInventory = new Inventory();
    
    [SerializeField]
    protected Vector2 ShootDirection = Vector2.up;

    [SerializeField]
    protected int jumpSpeed = 200;
    
	private float lifePoints { get => lifePoints; set => lifePoints = value; }
	
	private float lifePointsMax { get => lifePointsMax; set => lifePointsMax = value; }

	protected bool isOnGround = true;
}