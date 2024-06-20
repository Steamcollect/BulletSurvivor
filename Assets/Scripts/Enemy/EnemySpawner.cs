using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWaveData[] enemyWaveData;
    public Transform[] spawners;

    Transform target;
    PlayerHealth targetHealth;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetHealth = target.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        for (int i = 0; i < enemyWaveData.Length; i++)
        {
            StartCoroutine(Spawn(enemyWaveData[i]));
        }
    }

    private IEnumerator Spawn(EnemyWaveData enemyData)
    {
        GameObject tmp = Instantiate(enemyData.enemyPrefab, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
        EnemyController currentEnemy = tmp.GetComponent<EnemyController>();
        currentEnemy.targetHealth = targetHealth;
        currentEnemy.target = target;

        yield return new WaitForSeconds(enemyData.spawnCooldown);

        StartCoroutine(Spawn(enemyData));
    }
}

[System.Serializable] 
public class EnemyWaveData
{
    public GameObject enemyPrefab;
    public float spawnCooldown;
}
