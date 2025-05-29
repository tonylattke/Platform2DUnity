using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : BaseCharacter
{
    public Rigidbody2D playerRigidBody2D;
    
    [SerializeField]
    List<BaseGeometry> geometryPowers = new List<BaseGeometry>();

    [SerializeField] 
    private GameObject gameCore;
    
    private GameCore _gameCoreRef;

    private GeometryType _currentGeometryType = GeometryType.Box;
    
    BaseGeometry _currentGeometry;
    private SpriteRenderer _spriteRenderer;
    
    private BoxCollider2D _boxCollider2D;
    private CircleCollider2D _circleCollider2D;
    private PolygonCollider2D _polygonCollider2D;

    public int MovementDirection = 1; 
    
    [SerializeField]
    private int _dashSpeed = 200;

    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        _gameCoreRef = gameCore.GetComponent<GameCore>();
        
        // experiment
        playerRigidBody2D.freezeRotation = true;

        UpdateGeometryContent(geometryPowers[0]);
    }

    private void Update()
    {
        UpdateMovement();
        UpdateGeometryPower();
        UpdateExecuteSkill();
    }

    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-MathConstants.Left * (Time.deltaTime * Speed));
            MovementDirection = 1;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-MathConstants.Right * (Time.deltaTime * Speed));
            MovementDirection = -1;
        }
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
        if (collision.gameObject.tag.Equals(GameConstants.Singleton.killZone))
        {
            SceneManager.LoadScene("FinalScoreScreen");
            return;
        }
        
        if (collision.gameObject.tag.Equals(GameConstants.Singleton.earnPoints))
        {
            CheckEarnPoints(collision);
        }
        
        isOnGround = true;
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

    private void UpdateGeometryPower()
    {
        if (!Input.GetMouseButtonDown(1))
        {
            return;
        }

        _currentGeometryType++;
        if ((int) _currentGeometryType >= Enum.GetNames(typeof(GeometryType)).Length)
            _currentGeometryType = GeometryType.Box;

        foreach (var geometry in geometryPowers)
        {
            if (_currentGeometryType != geometry.GeometryType())
            {
                continue;
            }
            
            UpdateGeometryContent(geometry);
        }
    }

    private void UpdateGeometryContent(BaseGeometry newGeometry)
    {
        _currentGeometry = newGeometry;
        
        _spriteRenderer.sprite = _currentGeometry.sprite;
        _gameCoreRef.hudManager.UpdatePowerLogo(_currentGeometry);
        
        switch (_currentGeometryType)
        {
            case GeometryType.Box:
                _boxCollider2D.enabled = true;
                _circleCollider2D.enabled = false;
                _polygonCollider2D.enabled = false;
                break;
            case GeometryType.Circle:
                _boxCollider2D.enabled = false;
                _circleCollider2D.enabled = true;
                _polygonCollider2D.enabled = false;
                break;
            case GeometryType.Triangle:
                _boxCollider2D.enabled = false;
                _circleCollider2D.enabled = false;
                _polygonCollider2D.enabled = true;
                break;
        }
    }

    private void UpdateExecuteSkill()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            _currentGeometry.Skill(this);
        }
        else
        {
            RevertEffectsOfSkill();
        }
    }

    public int GetDashSpeed()
    {
        return _dashSpeed;
    }
    
    private void RevertEffectsOfSkill()
    {
        if (_currentGeometryType == GeometryType.Box)
            _currentGeometry.RecoverBoxSize(this);
        else
            _currentGeometry.RecoverNormalSizeAllGeometries(this);
    }
    
    private void CheckEarnPoints(Collision2D collision)
    {
        BaseObstacle obstacle = collision.gameObject.GetComponent<BaseObstacle>();
        if (obstacle == null)
            return;

        if (obstacle.consumedPoints)
            return;
        
        obstacle.consumedPoints = true;
        GameInstance.Singleton.AddPoints(obstacle.Points);
    }
}
