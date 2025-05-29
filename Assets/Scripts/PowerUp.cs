using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GeometryType GeomeType = GeometryType.Box;
    
    [SerializeField] 
    public float MinBoxScale = 0.5f;
    
    [SerializeField] 
    public float MaxBoxScale = 1f;
    
    [SerializeField]
    public int CircleDashSpeed = 300;

    [SerializeField]
    public int jumpSpeed = 400;

    [SerializeField]
    public float Duration = 5;
    
    [SerializeField]
    public int Points = 3;
}
