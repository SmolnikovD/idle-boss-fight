using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO Вынести UI
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private CurrencySystem currencySystem;
    [SerializeField]
    private ShopData shopData;

    [Header("Stats Buttons")]
    public Button statsAttackPowerButton;
    public Button statsClickPowerButton;
    public Button statsAttackRateButton;
    [Header("Skill Buttons")]
    public Button skillAttackPowerButton;
    public Button skillClickPowerButton;
    public Button skillAttackRateButton;

    public static event Action OnUpgrade;

    private void Awake()
    {
        statsAttackPowerButton.onClick.AddListener(() => ProccessButtonClick(statsAttackPowerButton, UpgradeType.StatsAttackPower));
        statsClickPowerButton.onClick.AddListener(() => ProccessButtonClick(statsClickPowerButton, UpgradeType.StatsClickPower));
        statsAttackRateButton.onClick.AddListener(() => ProccessButtonClick(statsAttackRateButton, UpgradeType.StatsAttackRate));

        skillAttackPowerButton.onClick.AddListener(() => ProccessButtonClick(skillAttackPowerButton, UpgradeType.SkillAttackPower));
        skillClickPowerButton.onClick.AddListener(() => ProccessButtonClick(skillClickPowerButton, UpgradeType.SkillClickPower));
        skillAttackRateButton.onClick.AddListener(() => ProccessButtonClick(skillAttackRateButton, UpgradeType.SkillAttackRate));
    }

    public void UpdateText(Button button, int newPrice)
    {
        button.gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(newPrice.ToString());
    }

    private void ProccessButtonClick(Button button, UpgradeType upgradeType)
    {
        if (currencySystem.Coins >= shopData.GetCost(upgradeType))
        {
            currencySystem.SpendCoins(shopData.GetCost(upgradeType));
            shopData.UpdateCost(upgradeType);
            UpdatePlayerStats(upgradeType);
            UpdateText(button, shopData.GetCost(upgradeType));
            OnUpgrade?.Invoke();
        }
    }

    private void UpdatePlayerStats(UpgradeType upgradeType)
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
