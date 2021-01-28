using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public GameObject spawnedEnemy;

    private delegate void SpawnEnemyDelegate();
    private SpawnEnemyDelegate SpawnEnemy;

    public Action<GameObject> OnEnemySpawned;
    public Action OnEnemyDeath;

    private void Start()
    {
        SpawnEnemy = SpawnRegularEnemy;
        SpawnEnemy();
    }

    public void PrepareBossFight()
    {
        SpawnEnemy = SpawnBoss;
    }

    public void OnEnemyDeathCallback()
    {
        OnEnemyDeath?.Invoke();
        SpawnEnemy();
    }

    private void SpawnRegularEnemy()
    {
        spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemy.GetComponent<Enemy>().OnEnemyDeath += OnEnemyDeathCallback;
        OnEnemySpawned?.Invoke(spawnedEnemy);
    }

    private void SpawnBoss()
    {
        SpawnEnemy = SpawnRegularEnemy;

        spawnedEnemy = Instantiate(bossPrefab, transform.position, Quaternion.identity);
        spawnedEnemy.GetComponent<Boss>().OnEnemyDeath += OnEnemyDeathCallback;
        OnEnemySpawned?.Invoke(spawnedEnemy);
    }

}
