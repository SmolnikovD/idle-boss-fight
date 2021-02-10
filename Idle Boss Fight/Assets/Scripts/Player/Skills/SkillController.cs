using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField]
    private PlayerDataController playerDataController;
    [SerializeField]
    private SkillButtonsUI skillButtonsUI;

    [SerializeField]
    private AttackPowerSkill attackPowerSkill;
    [SerializeField]
    private ClickPowerSkill clickPowerSkill;
    [SerializeField]
    private AttackRateSkill attackRateSkill;

    private Dictionary<UpgradeType, Skill> skillsDictionary = new Dictionary<UpgradeType, Skill>();

    private void Awake()
    {
        skillsDictionary.Add(UpgradeType.SkillAttackPower, attackPowerSkill);
        skillsDictionary.Add(UpgradeType.SkillClickPower, clickPowerSkill);
        skillsDictionary.Add(UpgradeType.SkillAttackRate, attackRateSkill);

        skillButtonsUI.OnSkillAttackPowerButtonClicked += () => attackPowerSkill.Perform(playerDataController);
        skillButtonsUI.OnSkillClickPowerButtonClicked += () => clickPowerSkill.Perform(playerDataController);
        skillButtonsUI.OnSkillClickRateButtonClicked += () => attackRateSkill.Perform(playerDataController);
    }

    public void TryUpgrade(UpgradeType upgradeType)
    {
        if (skillsDictionary[upgradeType].IsUnlocked)
        {
            skillsDictionary[upgradeType].Upgrade();
        }
        else
        {
            skillsDictionary[upgradeType].Unlock();
        }
    }
}
