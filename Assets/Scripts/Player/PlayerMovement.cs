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

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();

        }

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckPos + (Vector2)transform.position, checkRadius);
    }
}