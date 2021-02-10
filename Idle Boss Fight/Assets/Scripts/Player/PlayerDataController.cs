using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public Func<float> ModifiedAttackPower;
    public Func<float> ModifiedClickPower;
    public Func<float> ModifiedAttackRate;

    ////debug
    //public float modifiedAttackPower;
    //public float modifiedClickPower;
    //public float modifiedAttackRate;

    private readonly Dictionary<UpgradeType, Func<float>> playerDataDictionary = new Dictionary<UpgradeType, Func<float>>();
    private readonly Dictionary<UpgradeType, Action> playerDataUpdateDictionary = new Dictionary<UpgradeType, Action>();

    private void Awake()
    {
        InitializePlayerDataDictionary();
        InitializePlayerDataUpdateDictionary();
    }

    private void InitializePlayerDataDictionary()
    {
        playerDataDictionary.Add(UpgradeType.StatsAttackPower, () => { return ModifiedAttackPower != null ? ModifiedAttackPower.Invoke() : playerData.AttackPower; });
        playerDataDictionary.Add(UpgradeType.StatsClickPower, () => { return ModifiedClickPower != null ? ModifiedClickPower.Invoke() : playerData.ClickPower; });
        playerDataDictionary.Add(UpgradeType.StatsAttackRate, () => { return ModifiedAttackRate != null ? ModifiedAttackRate.Invoke() : playerData.AttackRate; });
    }

    private void InitializePlayerDataUpdateDictionary()
    {
        playerDataUpdateDictionary.Add(UpgradeType.StatsAttackPower, () => playerData.AttackPower += 1f);
        playerDataUpdateDictionary.Add(UpgradeType.StatsClickPower, () => playerData.ClickPower += 1f);
        playerDataUpdateDictionary.Add(UpgradeType.StatsAttackRate, () => playerData.AttackRate *= 0.9f);
    }

    public void UpgradeStats(UpgradeType statType)
    {
        playerDataUpdateDictionary[statType].Invoke();
    }

    public float GetStat(UpgradeType statType)
    {
        return playerDataDictionary[statType].Invoke();
    }


    ////debug
    //public void Update()
    //{
    //    modifiedAttackPower = playerDataDictionary[UpgradeType.StatsAttackPower].Invoke();
    //    modifiedClickPower = playerDataDictionary[UpgradeType.StatsClickPower].Invoke();
    //    modifiedAttackRate = playerDataDictionary[UpgradeType.StatsAttackRate].Invoke();
    //}
}
