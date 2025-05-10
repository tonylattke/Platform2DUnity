using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    protected int Speed = 5;
    
	[SerializeField]
    protected Inventory MyInventory = new Inventory();
    
    [SerializeField]
    protected Vector2 ShootDirection = Vector2.up;
}