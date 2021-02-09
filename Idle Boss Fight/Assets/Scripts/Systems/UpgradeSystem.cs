using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private CurrencySystem currencySystem;
    [SerializeField]
    private ShopUpgradeButtonsUI shopUpgradeButtonsUI;
    [SerializeField]
    private SkillController skillController;

    private readonly ShopData shopData = new ShopData();

    public static event Action OnUpgrade;

    private void Awake()
    {
        shopUpgradeButtonsUI.OnStatsUpgradeButtonClick += ProccessStatsUpgrade;
        shopUpgradeButtonsUI.OnSkillsUpgradeButtonClick += ProcessSkillUpgrade;
    }

    private void ProccessStatsUpgrade(Button button, UpgradeType upgradeType)
    {
        if (TryUpgrade(upgradeType))
        {
            shopUpgradeButtonsUI.UpdateText(button, shopData.GetCost(upgradeType));
            UpgradeStats(upgradeType);

            OnUpgrade?.Invoke();
        }
    }

    private void ProcessSkillUpgrade(Button button, UpgradeType upgradeType)
    {
        if (TryUpgrade(upgradeType))
        {
            shopUpgradeButtonsUI.UpdateText(button, shopData.GetCost(upgradeType));
            skillController.TryUpgrade(upgradeType);

            OnUpgrade?.Invoke();
        }
    }

    private bool TryUpgrade(UpgradeType upgradeType)
    {
        if (currencySystem.Coins >= shopData.GetCost(upgradeType))
        {
            currencySystem.SpendCoins(shopData.GetCost(upgradeType));
            shopData.IncreaseCost(upgradeType);
            return true;
        }
        return false;
    }

    private void UpgradeStats(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.StatsAttackPower:
                playerData.AttackPower += 1;
                break;
            case UpgradeType.StatsClickPower:
                playerData.ClickPower += 1;
                break;
            case UpgradeType.StatsAttackRate:
                playerData.AttackRate *= 0.8f;
                break;
        }
    }
}
