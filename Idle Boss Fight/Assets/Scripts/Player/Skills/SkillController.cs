using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private readonly Dictionary<UpgradeType, Skill> skillsDictionary = new Dictionary<UpgradeType, Skill>
    {
        { UpgradeType.SkillAttackPower, new AttackPowerSkill(1f,3f) },
        /////////////// skill2
        /////////////// skill3 
    };

    public void TryUpgrade(UpgradeType upgradeType)
    {
        if (CheckIfSkillUnlocked(upgradeType))
        {
            UpgradeSkill(upgradeType);
        }
        else
        {
            UnlockSkill(upgradeType);
        }
    }

    private bool CheckIfSkillUnlocked(UpgradeType upgradeType)
    {
        return skillsDictionary[upgradeType].IsUnlocked;
    }

    private void UnlockSkill(UpgradeType upgradeType)
    {
        skillsDictionary[upgradeType].IsUnlocked = true;
    }

    private void UpgradeSkill(UpgradeType upgradeType)
    {
        skillsDictionary[upgradeType].Upgrade();
    }
}
