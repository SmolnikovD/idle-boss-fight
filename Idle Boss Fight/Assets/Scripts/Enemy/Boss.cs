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

    public void BossDissappeared()
    {
        OnEnemyDeath?.Invoke(); // TODO Босс здесь не умирает, нужен другой ивент
        Destroy(this.gameObject);
    }
}
