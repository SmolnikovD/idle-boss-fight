using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Убрать дебаг
public class PlayerDataController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    private Dictionary<UpgradeType, Func<float>> playerDataDictionary = new Dictionary<UpgradeType, Func<float>>();

    private void Awake()
    {
        playerDataDictionary.Add(UpgradeType.SkillAttackPower, () => { return playerData.AttackPower; });
    }

    private void Start()
    {
        StartCoroutine(DebugCoroutine());
    }

    IEnumerator DebugCoroutine()
    {
        while (true)
        {
            Debug.Log(playerDataDictionary[UpgradeType.SkillAttackPower].Invoke());
            yield return new WaitForSeconds(1f);
        }
    }

    public void UpgradeStats(UpgradeType upgradeType)
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
