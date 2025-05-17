using UnityEngine;
using System.Collections.Generic;

public class Player : BaseCharacter
{
    Rigidbody2D playerRigidBody2D; 
    
    [SerializeField]
    float currentLifePoints = 10;
    
    [SerializeField]
    float maxLifePoints = 10;
    
    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        
        // experiment
        playerRigidBody2D.freezeRotation = true;
    }

    void Update()
    {
        UpdateMovement();
        Jump();
    }

    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-MathConstants.Left * (Time.deltaTime * Speed));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-MathConstants.Right * (Time.deltaTime * Speed));
        }
    }

    void Jump()
    {
        if (isOnGround && Input.GetKey(KeyCode.Space))
        {
            playerRigidBody2D.AddForce(new Vector2(0, jumpSpeed));
            isOnGround = false;
            //transform.Translate(MathConstants.Up * (Time.deltaTime * Speed*4));
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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider en trigger");
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collider en collision");
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isOnGround = true;
        }
        
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            if (currentLifePoints > 0)
                currentLifePoints--;
        }
    }

    public float GetLifePercentage()
    {
        return currentLifePoints / maxLifePoints;
    }
}
