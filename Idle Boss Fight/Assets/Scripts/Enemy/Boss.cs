using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public Action OnBossDefeated;

    protected override void Start()
    {
        Health = maxHealth;
        enemyUI.InitializeEnemyUI(maxHealth);
    }

    protected override void EnemyDeath()
    {
        OnBossDefeated?.Invoke();

        base.EnemyDeath();
    }
}
