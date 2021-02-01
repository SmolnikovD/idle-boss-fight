using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public event Action OnBossDefeated;

    protected override void Start()
    {
        Health = maxHealth * LevelManager.Level;
        enemyUI.InitializeEnemyUI(Health);
    }

    protected override void EnemyDeath()
    {
        OnBossDefeated?.Invoke();
        base.EnemyDeath();
    }

    public void BossDissappeared()
    {
        // TODO Нужен рефакторинг, не совпадают значения вызванных методов
        base.EnemyDeath();
    }
}
