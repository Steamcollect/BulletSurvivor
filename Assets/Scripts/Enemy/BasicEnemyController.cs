using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BasicEnemyController : EnemyController
{
    public override void Move()
    {
        rb.velocity = new Vector2(enemySpeed * Input.x, rb.velocity.y);
    }

    public override void Attack()
    {
        targetHealth.TakeDamage(attackDamage);
        StartCoroutine(AttackCooldown());
    }
}