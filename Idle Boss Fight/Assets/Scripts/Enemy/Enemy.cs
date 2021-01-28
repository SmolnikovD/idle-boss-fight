using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField]
    private int Health { get; set; }

    public EnemyDataSO enemyData;
    public EnemyUI enemyUI;

    public Action OnEnemyDeath;

    private void Start()
    {
        Health = enemyData.enemyMaxHealth;
        enemyUI.InitializeEnemyUI(enemyData.enemyName, enemyData.enemyMaxHealth);
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
