using UnityEngine;

public abstract class ProgressBar : MonoBehaviour
{
    [SerializeField] 
    public GameObject gameCoreRef;
    
    [SerializeField] 
    public GameObject barRef; // UI Image

    protected GameCore GameCore;
    private RectTransform _rectTransformBar;
    
    private Vector3 _scaleRepresenter = new Vector3(1,1,1);
    
    protected void Start()
    {
        GameCore = gameCoreRef.GetComponent<GameCore>();
        _rectTransformBar = barRef.GetComponent<RectTransform>();
    }

    protected void Update()
    {
        _scaleRepresenter.x = GetProgress();
        _rectTransformBar.localScale = _scaleRepresenter;
    }

    protected abstract float GetProgress();
}
