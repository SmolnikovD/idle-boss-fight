﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject bossPrefab;

    private GameObject spawnedEnemy;
    private Action SpawnEnemy;

    public event Action<GameObject> OnEnemySpawned;
    public event Action OnEnemyDeath;
    public event Action OnBossDefeated;
    
    private void Awake()
    {
        SpawnEnemy = SpawnRegularEnemy;
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void PrepareBossFight()
    {
        SpawnEnemy = SpawnBoss;
    }

    private void OnEnemyDeathCallback()
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
        spawnedEnemy.GetComponent<Boss>().OnBossDefeated += OnBossDefeated;
        OnEnemySpawned?.Invoke(spawnedEnemy);
    }
}
