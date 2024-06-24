using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBullet : MonoBehaviour
{
    public float enemyBulletSpeed;

    public int damage;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = transform.right * enemyBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject, 0.01f);
    }
}
