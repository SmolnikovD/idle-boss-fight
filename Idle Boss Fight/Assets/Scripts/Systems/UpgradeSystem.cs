using System;
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
    [SerializeField]
    private ShopDataController shopDataController;

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
            shopUpgradeButtonsUI.UpdateText(button, shopDataController.GetCost(upgradeType));
            performUpgradeAction(upgradeType);

            OnUpgrade?.Invoke();
        }
    }

    private bool TryUpgrade(UpgradeType upgradeType)
    {
        if (currencySystem.Coins >= shopDataController.GetCost(upgradeType))
        {
            currencySystem.SpendCoins(shopDataController.GetCost(upgradeType));
            shopDataController.IncreaseCost(upgradeType);
            return true;
        }
        return false;
    }
}
