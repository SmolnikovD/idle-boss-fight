using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public int Coins { get; private set; }

    public void AddCoins(int amount, Action updateUI)
    {
        Coins += amount;
        updateUI.Invoke();
    }

    public void AddCoins(int amount, int multiplier, Action updateUI)
    {
        Coins += amount * multiplier;
        updateUI.Invoke();
    }

    public void SpendCoins(int amount, Action updateUI)
    {
        Coins -= amount;
        updateUI.Invoke();
    }
}
