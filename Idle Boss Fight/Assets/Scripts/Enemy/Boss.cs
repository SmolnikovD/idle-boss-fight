using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    private BossFightTimer bossFight;
    [SerializeField]
    private ParticleSystem bossDeathVFX;

    public event Action OnBossDefeated;
    public event Action OnBossDissapeared;

    protected override void Start()
    {
        Health = maxHealth * LevelSystem.Level;
        enemyUI.InitializeEnemyUI(Health);
        bossFight.StartBossFightTimer(OnTimerEnd);
    }

    protected override void EnemyDeath()
    {
        OnBossDefeated?.Invoke();
        Instantiate(bossDeathVFX);
        base.EnemyDeath();
    }

    private void OnTimerEnd()
    {
        if(Health >= 0)
        {
            OnBossDissapeared?.Invoke();
            Instantiate(bossDeathVFX);
            base.EnemyDeath();
        }
    }
}
