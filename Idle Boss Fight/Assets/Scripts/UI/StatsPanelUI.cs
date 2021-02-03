using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanelUI : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

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
        attackPowerText.SetText(playerData.AttackPower.ToString());
        clickPowerText.SetText(playerData.ClickPower.ToString());
        attackRateText.SetText(playerData.AttackRate.ToString());
    }

    public void UpdateCoinsUI(int amount)
    {
        coinsText.SetText(amount.ToString());
    }
}
