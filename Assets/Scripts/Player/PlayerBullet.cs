using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float playerBulletSpeed;

    public int damage;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        rb.velocity = transform.right * playerBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject, 0.01f);
    }
}
