using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWaveData[] enemyWaveData;
    public Transform[] spawners;
    bool CanSpawn = true;

    void Start()
    {
        
    }
    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(enemyWaveData.enemyPrefab);
    }
}

[System.Serializable] 
public class EnemyWaveData
{
    public GameObject enemyPrefab;
    public float spawnCooldown;
}
