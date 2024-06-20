using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float currentEnemyHealth;
    public float maxEnemyHealth;

    EnemyController enemyController;
    Animator anim;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        StartCoroutine(enemyController.FreezMovement(.1f));

        if(currentEnemyHealth <= 0)
        {
            anim.SetTrigger("Die");
            StartCoroutine(Die());
            enemyController.Die();
        }
        else
        {
            anim.SetTrigger("TakeDamage");
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.7f);

        Destroy(gameObject);
    }
}
