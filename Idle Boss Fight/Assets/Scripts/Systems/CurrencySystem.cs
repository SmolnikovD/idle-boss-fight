using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    private CurrencyData currencyData = new CurrencyData();
    [SerializeField]
    private AudioClip coinSound;

    public int Coins { get => currencyData.coins; private set => currencyData.coins = value; }

    public static event Action OnCoinsAmountChanged;

    private void Awake()
    {
        currencyData = SaveSystem.Load(currencyData);
        EnemySpawner.OnEnemyDeath += (enemy) => AddCoins(enemy.GetComponent<Enemy>().CoinsReward, LevelSystem.Level);
        OnCoinsAmountChanged += () => AudioPlayer.Instance.Play(coinSound);
    }

    public void AddCoins(int amount, int multiplier)
    {
        Coins += amount * multiplier;
        OnCoinsAmountChanged?.Invoke();
    }

    public void SpendCoins(int amount)
    {
        Coins -= amount;
        OnCoinsAmountChanged?.Invoke();
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        SaveSystem.Save(currencyData);
    }
#endif

#if UNITY_ANDROID
    private void OnApplicationPause()
    {
        SaveSystem.Save(currencyData);
    }
#endif
}
