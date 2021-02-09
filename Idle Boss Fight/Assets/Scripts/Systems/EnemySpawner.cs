using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject bossPrefab;

    private Action SpawnEnemy;

    public static event Action<GameObject> OnEnemySpawned;
    public static event Action<GameObject> OnEnemyDeath;
    public static event Action OnBossDefeated;
    public static event Action OnBossDissapeared;

    private void Awake()
    {
        SpawnEnemy = SpawnRegularEnemy;
        BossButtonUI.OnFightBossButtonPressed += PrepareBossFight;

        OnEnemyDeath += (x) => SpawnEnemy();
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void PrepareBossFight()
    {
        SpawnEnemy = SpawnBoss;
    }

    private void SpawnRegularEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>();
        enemy.OnEnemyDeath += OnEnemyDeath;

        OnEnemySpawned?.Invoke(enemy.gameObject);
    }

    private void SpawnBoss()
    {
        SpawnEnemy = SpawnRegularEnemy;

        Boss boss = Instantiate(bossPrefab, transform.position, Quaternion.identity).GetComponent<Boss>();
        boss.OnEnemyDeath += OnEnemyDeath;
        boss.OnBossDefeated += OnBossDefeated;
        boss.OnBossDissapeared += OnBossDissapeared;

        OnEnemySpawned?.Invoke(boss.gameObject);
    }
}
