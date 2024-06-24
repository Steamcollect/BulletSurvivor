using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangeEnemy : EnemyController
{
    public override void Move()
    {
        rb.velocity = new Vector2(enemySpeed * Input.x, rb.velocity.y);
    }

    public override void Attack()
    {
        
    }
}
