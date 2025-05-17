using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : BaseCharacter
{
    Rigidbody2D playerRigidBody2D; 
    
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
        if (collision.gameObject.tag.Equals(GameConstants.Singleton.groundTag))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(GameConstants.Singleton.groundTag))
        {
            isOnGround = true;
        }
    }

    public float GetLifePercentage()
    {
        return GameInstance.Singleton.currentLifePoints / GameInstance.Singleton.maxLifePoints;
    }

    public void ReceiveDamage(GameObject otherObject, float damagePoints)
    {
        if (GameInstance.Singleton.currentLifePoints - damagePoints > 0)
        {
            GameInstance.Singleton.currentLifePoints -= damagePoints;
            return;
        }
        
        // TODO destroy and report  
        SceneManager.LoadScene(GameConstants.Singleton.finalScoreScreenName);
    }
}
