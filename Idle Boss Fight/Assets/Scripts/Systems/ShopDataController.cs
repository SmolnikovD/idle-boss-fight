using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopDataController : MonoBehaviour
{
    private ShopData shopData = new ShopData();
    private Dictionary<UpgradeType, Func<int>> costDictionary;
    private Dictionary<UpgradeType, Action> costUpgradeDictionary;

    private void Awake()
    {
        shopData = SaveSystem.Load(shopData);

        InitializeCostDictionary();
        InitializeUpgradeCostDictionary();
    }

    private void InitializeCostDictionary()
    {
        costDictionary = new Dictionary<UpgradeType, Func<int>>()
        {
            {UpgradeType.StatsAttackPower, () => shopData.statsAttackPowerCost },
            {UpgradeType.StatsClickPower, () => shopData.statsClickPowerCost },
            {UpgradeType.StatsAttackRate, () => shopData.statsAttackRateCost },
            {UpgradeType.SkillAttackPower, () => shopData.skillAttackPowerCost },
            {UpgradeType.SkillClickPower, () => shopData.skillClickPowerCost },
            {UpgradeType.SkillAttackRate, () => shopData.skillAttackRateCost}
        };
    }

    private void InitializeUpgradeCostDictionary()
    {
        costUpgradeDictionary = new Dictionary<UpgradeType, Action>()
        {
            {UpgradeType.StatsAttackPower, () => StatCostUpgradeAction(ref shopData.statsAttackPowerCost, 10) },
            {UpgradeType.StatsClickPower, () => StatCostUpgradeAction(ref shopData.statsClickPowerCost, 20) },
            {UpgradeType.StatsAttackRate, () => StatCostUpgradeAction(ref shopData.statsAttackRateCost, 30) },
            {UpgradeType.SkillAttackPower, () => SkillCostUpgradeAction(ref shopData.skillAttackPowerCost, 2) },
            {UpgradeType.SkillClickPower, () => SkillCostUpgradeAction(ref shopData.skillClickPowerCost, 2) },
            {UpgradeType.SkillAttackRate, () => SkillCostUpgradeAction(ref shopData.skillAttackRateCost, 2) }
        };
    }

    public int GetCost(UpgradeType upgradeType)
    {
        return costDictionary[upgradeType].Invoke();
    }

    private void StatCostUpgradeAction(ref int stat, int cost) => stat += cost * LevelSystem.Level;
    private void SkillCostUpgradeAction(ref int stat, int cost) => stat *= cost;

    public void IncreaseCost(UpgradeType upgradeType)
    {
        costUpgradeDictionary[upgradeType].Invoke();
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        SaveSystem.Save(shopData);
    }
#endif

#if UNITY_ANDROID
    private void OnApplicationPause()
    {
        SaveSystem.Save(shopData);
    }
#endif
}
