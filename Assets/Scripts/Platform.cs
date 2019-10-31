using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    private SpriteRenderer sprite;
    private bool isBoosted = false;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        animator.enabled = false;
        sprite = GetComponent<SpriteRenderer>();
        
        if (Random.Range(0, 5) == 1)
        {
            isBoosted = true;
            sprite.color = Color.cyan;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y > 0f)
            return;

        Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
        if (rb == null)
            return;

        PlayerSprite.Instance.ActivateJumpAnimation();

        Vector2 velocity = rb.velocity;
        velocity.y = isBoosted ? jumpForce * 2 : jumpForce;
        rb.velocity = velocity;

    }
}
