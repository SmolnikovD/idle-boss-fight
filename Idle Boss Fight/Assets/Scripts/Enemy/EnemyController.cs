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
    [SerializeField]
    private ParticleSystem bossDissappearingVFX;

    private void Awake()
    {
        BossButtonUI.OnFightBossButtonPressed += PrepareBossFight;
        BossFight.OnBossFightTimerEnded += () => bossDissappearingVFX.Play();
    }

    public void PrepareBossFight()
    {
        spawner.PrepareBossFight();
        EnemySpawner.OnEnemySpawned += StartBossFightTimer;
    }

    private void StartBossFightTimer(GameObject bossGameObject)
    {
        bossFight.StartBossFightTimer(bossGameObject.GetComponent<Boss>());
        EnemySpawner.OnEnemySpawned -= StartBossFightTimer;
        bossGameObject.GetComponentInChildren<BossTimerUI>().BossTime = bossFight.timer;
    }
}
