﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner spawner;
    [SerializeField]
    private BossFight bossFight;
    [SerializeField]
    private ParticleSystem bossDissappearingVFX;


    public event Action<GameObject> OnEnemySpawned;
    public event Action OnEnemyDeath;
    public event Action OnBossFightTimerEnded;
    public event Action OnBossDefeated;

    private void Awake()
    {
        spawner.OnEnemySpawned += OnEnemySpawned;
        spawner.OnEnemyDeath += OnEnemyDeath;
        spawner.OnBossDefeated += OnBossDefeated;
        bossFight.OnBossFightTimerEnded += OnBossFightTimerEnded;
        bossFight.OnBossFightTimerEnded += () => bossDissappearingVFX.Play();
    }

    public void PrepareBossFight()
    {
        spawner.PrepareBossFight();
        spawner.OnEnemySpawned += StartBossFightTimer;
    }

    private void StartBossFightTimer(GameObject bossGameObject)
    {
        bossFight.StartBossFightTimer(bossGameObject.GetComponent<Boss>());
        spawner.OnEnemySpawned -= StartBossFightTimer;
        bossGameObject.GetComponentInChildren<BossTimerUI>().BossTime = bossFight.timer;
    }
}
