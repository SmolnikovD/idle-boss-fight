using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerDataController playerDataController;
    [SerializeField]
    private SkillController skillController;
    [SerializeField]
    private CurrencySystem currencySystem;
    [SerializeField]
    private ShopUpgradeButtonsUI shopUpgradeButtonsUI;

    private readonly ShopData shopData = new ShopData();

    public static event Action OnUpgrade;

    private void Awake()
    {
        shopUpgradeButtonsUI.OnStatsUpgradeButtonClick += (button, upgradeType) => ProccessUpgrade(button, upgradeType, (type) => playerDataController.UpgradeStats(type));
        shopUpgradeButtonsUI.OnSkillsUpgradeButtonClick += (button, upgradeType) => ProccessUpgrade(button, upgradeType, (type) => skillController.TryUpgrade(type));
    }

    private void ProccessUpgrade(Button button, UpgradeType upgradeType, Action<UpgradeType> performUpgradeAction)
    {
        if (TryUpgrade(upgradeType))
        {
            shopUpgradeButtonsUI.UpdateText(button, shopData.GetCost(upgradeType));
            performUpgradeAction(upgradeType);

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
}
