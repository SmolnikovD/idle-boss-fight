using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [field: SerializeField]
    public int Coins { get; private set; }

    public static event Action<int> OnCoinsAmountChanged;

    private void Awake()
    {
        EnemySpawner.OnEnemyDeath += (enemy) => AddCoins(enemy.GetComponent<Enemy>().CoinsReward, LevelSystem.Level);
    }

    public void AddCoins(int amount, int multiplier)
    {
        Coins += amount * multiplier;
        OnCoinsAmountChanged?.Invoke(Coins);
    }

    public void SpendCoins(int amount)
    {
        Coins -= amount;
        OnCoinsAmountChanged?.Invoke(Coins);
    }
}
