using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUlt : MonoBehaviour
{
    public float ultSpeed;

    public LayerMask enemyLayer;


    public int ultDamage;
    public Rigidbody2D rb;
    public float ultRadius;

    public GameObject explosionPrefabs;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = transform.right * ultSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Explode();
        Destroy(gameObject, 0.01f);
    }

    void Explode()
    {
        Destroy(Instantiate(explosionPrefabs, transform.position, transform.rotation), .4f);

        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, ultRadius, enemyLayer);
        foreach (Collider2D hit in collisions)
        {
            hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(ultDamage);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ultRadius);
    }
}
