using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [Header("Movement statistics")]
    public float enemySpeed;

    [Header("Combat statistics")]
    public float attackRange;
    public float attackCooldown;
    public int attackDamage;

    [HideInInspector]public bool canAttack = true;

    [HideInInspector] public Transform target;
    [HideInInspector] public PlayerHealth targetHealth;
    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < attackRange && canAttack)
        {
            Attack();
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    public abstract void Move();

    public abstract void Attack();
    public IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public Vector2 Input
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


            return new Vector2(x, y);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}