using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject, 0.01f);
    }
}
