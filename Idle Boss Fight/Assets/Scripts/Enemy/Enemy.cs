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

    public EnemyUI enemyUI;

    public Action OnEnemyDeath;

    protected virtual void Start()
    {
        Health = maxHealth;
        enemyUI.InitializeEnemyUI("Enemy", maxHealth);
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

    public void EnemyDeath()
    {
        OnEnemyDeath?.Invoke();
        Destroy(this.gameObject);
    }
}
