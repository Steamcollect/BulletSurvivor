using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BasicEnemyController : MonoBehaviour
{
    public float enemySpeed;

    public float attackRange;
    public float attackCooldown;
    public int attackDamage;

    bool canAttack = true;

    public Transform target;
    public PlayerHealth targetHealth;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) < attackRange && canAttack)
        {
            StartCoroutine(Attack());
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(enemySpeed * Input.x, rb.velocity.y);
    }

    IEnumerator Attack()
    {
        targetHealth.TakeDamage(attackDamage);
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    Vector2 Input
    { 
        get
        {
            float x, y;

            if (target.position.x < transform.position.x && Vector2.Distance(target.position, transform.position) > attackRange) x = -1;
            else if (target.position.x > transform.position.x && Vector2.Distance(target.position, transform.position) > attackRange) x = 1; 
            else x = 0;
            
            if (target.position.y < transform.position.y && Vector2.Distance(target.position, transform.position) > attackRange) y = -1;
            else if (target.position.y > transform.position.y && Vector2.Distance(target.position, transform.position) > attackRange) y = 1; 
            else y = 0;


            return new Vector2(x,y);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}