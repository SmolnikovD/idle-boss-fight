using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanelUI : MonoBehaviour
{
    [SerializeField]
    private PlayerDataController playerDataController;

    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private TextMeshProUGUI attackPowerText;
    [SerializeField]
    private TextMeshProUGUI clickPowerText;
    [SerializeField]
    private TextMeshProUGUI attackRateText;

    private void Awake()
    {
        UpgradeSystem.OnUpgrade += UpdateStatsPanelUI;
        CurrencySystem.OnCoinsAmountChanged += UpdateCoinsUI;
    }

    public void UpdateStatsPanelUI()
    {
        attackPowerText.SetText(playerDataController.GetStat(UpgradeType.StatsAttackPower).ToString());
        clickPowerText.SetText(playerDataController.GetStat(UpgradeType.StatsClickPower).ToString());
        attackRateText.SetText(playerDataController.GetStat(UpgradeType.StatsAttackRate).ToString());
    }

    public void UpdateCoinsUI(int amount)
    {
        coinsText.SetText(amount.ToString());
    }
}
