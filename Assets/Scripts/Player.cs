using UnityEngine;
using System.Collections.Generic;

public class Player : BaseCharacter
{
    void Start()
    {
        
    }

    void Update()
    {
        UpdateMovement();
        UpdateShoot();
    }

    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(MathConstants.Up * Time.deltaTime * Speed);
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(MathConstants.Down * Time.deltaTime * Speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(MathConstants.Left * Time.deltaTime * Speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(MathConstants.Right * Time.deltaTime * Speed);
        }
    }

    void UpdateShoot()
    {
        GameObject MyWeapon = MyInventory.GetCurrentWeaponGameObject();
        if (MyWeapon == null)
            return;

        WeaponBase WeaponBaseComponent = MyWeapon.GetComponent<WeaponBase>();

        if (Input.GetKey(KeyCode.Space) && WeaponBaseComponent.IsReady())
            StartCoroutine(WeaponBaseComponent.Shoot(this.gameObject));
    }
}
