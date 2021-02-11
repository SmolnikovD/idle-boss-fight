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

    [SerializeField]
    protected EnemyUI enemyUI;
    [SerializeField]
    protected EnemyAnimations enemyAnimations;
    [SerializeField]
    protected GameObject enemyDeathVFX;

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
        PlayerAttack.OnPlayerAttack -= GetDamage;
        OnEnemyDeath?.Invoke(this.gameObject);

        enemyUI.gameObject.SetActive(false);
        enemyAnimations.SetDeathAnimation();
        var vfx = Instantiate(enemyDeathVFX);
        Destroy(vfx, 1f);

        Destroy(this.gameObject, 0.5f);
    }
}
