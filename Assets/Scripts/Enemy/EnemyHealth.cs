using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float currentEnemyHealth;
    public float maxEnemyHealth;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;

        if(currentEnemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
