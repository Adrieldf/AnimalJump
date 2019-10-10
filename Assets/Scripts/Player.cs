using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static Player Instance;
    void Awake() => Instance = this;

    #region Stats
    [Header("Player Stats")]
    public int MaxHealth = 3;
    public int CurrentHealth = 3;
    public float movementSpeed = 7f;
    #endregion
    [Header("Other")]
    Rigidbody2D rb;
    float movement = 0f;
    public Transform gameCamera;
    private bool isDead = false;
    private float movementInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Debug.Log(movementInput);
        movement = movementInput * movementSpeed;

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WebGLPlayer)
            movement = Input.GetAxis("Horizontal") * movementSpeed;
    }

    public void RightInputClick(bool clickDown)
    {
        if (clickDown)
            movementInput = 1;
        else
            movementInput = 0;
    }
    public void LeftInputClick(bool clickDown)
    {
        if (clickDown)
            movementInput = -1;
        else
            movementInput = 0;
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;

        //rotate around the screen
        if (transform.position.x > 3.4f)
        {
            velocity.x = -movement;
            transform.position = new Vector3(-3.2f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -3.4f)
        {
            velocity.x = -movement;
            transform.position = new Vector3(3.2f, transform.position.y, transform.position.z);
        }
        else
        {
            velocity.x = movement;
        }
        rb.velocity = velocity;

        //se o jogador sair da visão da camera
        if (transform.position.y - gameCamera.position.y < -5)
            Die();

    }
    void Die()
    {
        if (!isDead)
        {
            isDead = true;
            GameMasterController.Instance.ShowDeathPanel();
        }
    }

    public void SpikeHit()
    {
        CurrentHealth--;
        GameMasterController.Instance.UpdateLifePanel();
        if(CurrentHealth == 0)
        {
            Die();
        }
    }
    public bool HeartPickup()
    {
        if (CurrentHealth == MaxHealth) return false;
        Debug.Log("pickup");
        CurrentHealth++;
        GameMasterController.Instance.UpdateLifePanel();
        return true;
    }
}

