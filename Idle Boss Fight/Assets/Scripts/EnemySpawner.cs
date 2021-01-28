using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnedEnemy;

    public Action<GameObject> OnEnemySpawned;
    public Action OnEnemyDeath;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemy.GetComponent<Enemy>().OnEnemyDeath += OnEnemyDeathCallback;
        OnEnemySpawned?.Invoke(spawnedEnemy);
    }

    public void OnEnemyDeathCallback()
    {
        OnEnemyDeath?.Invoke();
        SpawnEnemy();
    }
}
