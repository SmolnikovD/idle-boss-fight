using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float enemySpawnDelay = 1f;

    public GameObject enemyPrefab;

    public Action<GameObject> OnEnemySpawned;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().OnEnemyDeath += OnEnemyDeath;
        OnEnemySpawned?.Invoke(enemy);
    }

    public void OnEnemyDeath()
    {
        StartCoroutine(WaitBeforeNextEnemySpawn());
    }

    private IEnumerator WaitBeforeNextEnemySpawn()
    {
        yield return new WaitForSeconds(enemySpawnDelay);
        SpawnEnemy();
    }
}
