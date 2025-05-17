using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class HUDManager
{
    [SerializeField]
    private GameObject inGameUI;


    public void HideInGameUI()
    {
        inGameUI.SetActive(false);
    }
}