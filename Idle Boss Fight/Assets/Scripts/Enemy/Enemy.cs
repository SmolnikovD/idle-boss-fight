using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth;
    [field: SerializeField]
    protected int Health { get; set; }

    [SerializeField]
    public int coinsReward = 1;

    public EnemyUI enemyUI;

    public event Action OnEnemyDeath;

    protected virtual void Start()
    {
        Health = maxHealth * LevelSystem.Level;
        enemyUI.InitializeEnemyUI(Health);
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            EnemyDeath();
        }
        enemyUI.UpdateHealthBarUI(Health);
    }

    protected virtual void EnemyDeath()
    {
        OnEnemyDeath?.Invoke();
        Destroy(this.gameObject);
    }

    public int GetHealth()
    {
        return Health;
    }
}
