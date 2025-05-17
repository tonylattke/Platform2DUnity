using UnityEngine;
using TMPro;

public class FinalScoreScreenCore : BaseScreenCore
{
    [SerializeField] 
    public TextMeshProUGUI scoreUIText;

    private new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
        
        scoreUIText.text = "Score: " + GameInstance.Singleton.currentScore;
    }
}
