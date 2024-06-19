using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed, jumpForce;


    [Header("Check")]
    public LayerMask groundLayer;
    public float checkRadius;
    public Vector2 groundCheckPos;

    float xInput;

    Animator animator;
    SpriteRenderer graphics;
    Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        graphics = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();

        }

        Flip();
        SetAnimation();

        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    bool IsGrounded
    {
        get { return Physics2D.OverlapCircle(groundCheckPos + (Vector2)transform.position, checkRadius, groundLayer); }
    }

    void Flip()
    {
        if (rb.velocity.x > 0.1)
        {
            graphics.flipX = false;
        }
        else if(rb.velocity.x < -0.1)
        {
            graphics.flipX = true;
        }
    }

    void SetAnimation()
    {
        animator.SetFloat("Xvelocity", Mathf.Abs(rb.velocity.x));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckPos + (Vector2)transform.position, checkRadius);
    }
}