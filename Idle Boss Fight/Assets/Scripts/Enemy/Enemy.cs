using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [field: SerializeField]
    private int Health { get; set; }

    public EnemyUI enemyUI;

    public Action OnEnemyDeath;

    private void Start()
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
        Debug.Log("Enemy Dead");
        Destroy(this.gameObject);
    }
}
