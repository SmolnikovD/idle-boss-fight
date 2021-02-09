using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeButtonsUI : MonoBehaviour
{
    [Header("Stats Buttons")]
    public Button statsAttackPowerButton;
    public Button statsClickPowerButton;
    public Button statsAttackRateButton;
    [Header("Skill Buttons")]
    public Button skillAttackPowerButton;
    public Button skillClickPowerButton;
    public Button skillAttackRateButton;

    public event Action<Button, UpgradeType> OnStatsUpgradeButtonClick;
    public event Action<Button, UpgradeType> OnSkillsUpgradeButtonClick;

    private void Awake()
    {
        statsAttackPowerButton.onClick.AddListener(() => OnStatsUpgradeButtonClick(statsAttackPowerButton, UpgradeType.StatsAttackPower));
        statsClickPowerButton.onClick.AddListener(() => OnStatsUpgradeButtonClick(statsClickPowerButton, UpgradeType.StatsClickPower));
        statsAttackRateButton.onClick.AddListener(() => OnStatsUpgradeButtonClick(statsAttackRateButton, UpgradeType.StatsAttackRate));

        skillAttackPowerButton.onClick.AddListener(() => OnSkillsUpgradeButtonClick(skillAttackPowerButton, UpgradeType.SkillAttackPower));
        skillClickPowerButton.onClick.AddListener(() => OnSkillsUpgradeButtonClick(skillClickPowerButton, UpgradeType.SkillClickPower));
        skillAttackRateButton.onClick.AddListener(() => OnSkillsUpgradeButtonClick(skillAttackRateButton, UpgradeType.SkillAttackRate));
    }


    public void UpdateText(Button button, int newPrice)
    {
        button.gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(newPrice.ToString());
    }
}
