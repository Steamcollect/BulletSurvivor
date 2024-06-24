using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float currentEnemyHealth;
    public float maxEnemyHealth;
    public float defaultEnemyHealth;

    public float chargeGiven;
    public float scoreGiven;

    public float multiplier = 1;

    EnemyController enemyController;
    Animator anim;



    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        multiplier += ScoreManager.instance.score / 20 ;
        currentEnemyHealth = defaultEnemyHealth * multiplier;
        if (currentEnemyHealth > maxEnemyHealth) currentEnemyHealth = maxEnemyHealth;
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
            PlayerCombat.instance.AddUltCharge(chargeGiven * multiplier /2);
            ScoreManager.instance.AddScore(scoreGiven * multiplier);
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
