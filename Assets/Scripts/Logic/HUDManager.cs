using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HUDManager
{
    [SerializeField]
    private GameObject inGameUI;

    [SerializeField] 
    private Image PowerLogo;

    public void HideInGameUI()
    {
        inGameUI.SetActive(false);
    }

    public void UpdatePowerLogo(BaseGeometry geometry)
    {
        PowerLogo.sprite = geometry.sprite;
        // PowerLogo.color = geometry.logoColor; TODO not working for some reason
    }
}