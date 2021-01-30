using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner spawner;
    [SerializeField]
    private BossFight bossFight;

    public Action<GameObject> OnEnemySpawned;
    public Action OnEnemyDeath;
    public Action OnBossFightTimerEnded;
    public Action OnBossDefeated;


    private void Awake()
    {
        spawner.OnEnemySpawned += OnEnemySpawned;
        spawner.OnEnemyDeath += OnEnemyDeath;
        spawner.OnBossDefeated += OnBossDefeated;
        bossFight.OnBossFightTimerEnded += OnBossFightTimerEnded;
    }

    public void PrepareBossFight()
    {
        spawner.PrepareBossFight();
        spawner.OnEnemySpawned += StartBossFightTimer;
    }

    private void StartBossFightTimer(GameObject go)
    {
        bossFight.StartBossFightTimer();
        spawner.OnEnemySpawned -= StartBossFightTimer;
    }
}
