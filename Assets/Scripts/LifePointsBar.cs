using UnityEngine;

public class LifePointsBar : ProgressBar
{
    private Player _playerRef;

    private new void Start()
    {
        base.Start();
        _playerRef = GameCore.playerRef.GetComponent<Player>();
    }

    protected override float GetProgress()
    {
        return _playerRef.GetLifePercentage();
    }
}
