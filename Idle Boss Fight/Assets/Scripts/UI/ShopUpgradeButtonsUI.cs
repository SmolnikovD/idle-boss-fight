using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeButtonsUI : MonoBehaviour
{
    [SerializeField]
    private ShopDataController shopDataController;

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

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        UpdateText(statsAttackPowerButton, shopDataController.GetCost(UpgradeType.StatsAttackPower));
        UpdateText(statsClickPowerButton, shopDataController.GetCost(UpgradeType.StatsClickPower));
        UpdateText(statsAttackRateButton, shopDataController.GetCost(UpgradeType.StatsAttackRate));

        UpdateText(skillAttackPowerButton, shopDataController.GetCost(UpgradeType.SkillAttackPower));
        UpdateText(skillClickPowerButton, shopDataController.GetCost(UpgradeType.SkillClickPower));
        UpdateText(skillAttackRateButton, shopDataController.GetCost(UpgradeType.SkillAttackRate));
    }

    public void UpdateText(Button button, int cost)
    {
        button.gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(cost.ToString());
    }
}
