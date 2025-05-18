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

    public void Skill(GameObject gameObject)
    {
        switch (geomType)
        {
            case global::GeometryType.Box:
                BoxHSkill(gameObject);
                break;
            case global::GeometryType.Circle:
                CircleSkill(gameObject);
                break;
            case global::GeometryType.Triangle:
                TriangleSkill(gameObject);
                break;
        }
    }
    
    public GeometryType GeometryType()
    {
        return geomType;
    }
    
    public void BoxHSkill(GameObject gameObject)
    {
        // TODO
    }
    
    public void CircleSkill(GameObject gameObject)
    {
        // TODO
    }
    
    public void TriangleSkill(GameObject gameObject)
    {
        // TODO
    }
}
