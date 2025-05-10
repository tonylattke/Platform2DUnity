using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
	[SerializeField]
    private CreatureType CurrentCreatureType = CreatureType.None;
    
    [SerializeField]
    List<GameObject> Weapons = new List<GameObject>();
    
    public CreatureType GetCurrentCreatureType()
    {
        return CurrentCreatureType;
    }

    public GameObject GetCurrentWeaponGameObject()
    {
        foreach (var Weapon in Weapons)
        {
            WeaponBase WeaponBaseComponent = Weapon.GetComponent<WeaponBase>();
            if (WeaponBaseComponent != null && WeaponBaseComponent.CurrentCreatureType == CurrentCreatureType)
            {
                return Weapon;
            }
        }
        
        Debug.Log("Weapon not found");
        return null;
    }
}