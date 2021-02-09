using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth;
    [field: SerializeField]
    public int Health { get; protected set; }

    [field: SerializeField]
    public int CoinsReward { get; protected set; } = 10;

    public EnemyUI enemyUI;

    public event Action<GameObject> OnEnemyDeath;

    private void Awake()
    {
        PlayerAttack.OnPlayerAttack += GetDamage;
    }

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
        OnEnemyDeath?.Invoke(this.gameObject);
        Destroy(this.gameObject);
    }

    public void OnDestroy()
    {
        PlayerAttack.OnPlayerAttack -= GetDamage;
    }
}
