using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData
{
    private readonly Dictionary<UpgradeType, List<int>> costDictionary = new Dictionary<UpgradeType, List<int>>()
    {
        {UpgradeType.StatsAttackPower, new List<int>{ 10, 10 * LevelSystem.Level } },
        {UpgradeType.StatsClickPower, new List<int>{ 50, 50 * LevelSystem.Level } },
        {UpgradeType.StatsAttackRate, new List<int>{ 100, 100 * LevelSystem.Level } },
        {UpgradeType.SkillAttackPower, new List<int>{ 200, 2} },
        {UpgradeType.SkillClickPower, new List<int>{ 600, 3} },
        {UpgradeType.SkillAttackRate, new List<int>{ 1000, 4} },
    };

    public int GetCost(UpgradeType upgradeType)
    {
        return costDictionary[upgradeType][0];
    }

    public void IncreaseCost(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.StatsAttackPower:
            case UpgradeType.StatsClickPower:
            case UpgradeType.StatsAttackRate:
                costDictionary[upgradeType][0] += costDictionary[upgradeType][1];
                break;
            case UpgradeType.SkillAttackPower:
            case UpgradeType.SkillClickPower:
            case UpgradeType.SkillAttackRate:
                costDictionary[upgradeType][0] *= costDictionary[upgradeType][1];
                break;
            default: break;
        }
    }
}

public enum UpgradeType
{
    StatsAttackPower,
    StatsClickPower,
    StatsAttackRate,
    SkillAttackPower,
    SkillClickPower,
    SkillAttackRate
}
