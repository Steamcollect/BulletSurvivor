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

    bool canMove = true;

    [HideInInspector]public bool canAttack = true;

    public Transform target;
    [HideInInspector] public PlayerHealth targetHealth;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator anim;

    SpriteRenderer graphics;
    Collider2D collid;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        TryGetComponent<Animator>(out anim);
        graphics = GetComponent<SpriteRenderer>();
        collid = GetComponent<Collider2D>();
    }

    private void Start()
    {
        StartCoroutine(FreezMovement(1f));
        StartCoroutine(SetCollid());
    }

    IEnumerator SetCollid()
    {
        yield return new WaitForSeconds(.5f);

        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        collid.isTrigger = true;
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < attackRange && canAttack)
        {
            Attack();
        }

        if (anim) SetAnimation();
    }
    void FixedUpdate()
    {
        Move();
    }

    public abstract void Move();

    public abstract void Attack();
    public void ApplyDamage()
    {
        targetHealth.TakeDamage(attackDamage);
    }

    public IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void SetAnimation()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.x + Input.y));
        if (rb.velocity.x < -1f) graphics.flipX = true;
        else if (rb.velocity.x > .1f) graphics.flipX = false;
    }

    public IEnumerator FreezMovement(float delay)
    {
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    public void Die()
    {
        StopAllCoroutines();

        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        collid.enabled = false;
        canAttack = false;
        canMove = false;
    }

    public Vector2 Input
    {
        get
        {
            if (!canMove) return Vector2.zero;

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