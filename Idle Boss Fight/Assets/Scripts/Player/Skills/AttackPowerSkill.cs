using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerSkill : Skill
{
    protected override string SAVE_DATA_ID => "AttackPower";

    public override void Perform(PlayerDataController playerDataController)
    {
        float attackPowerToModify = playerDataController.GetStat(UpgradeType.StatsAttackPower);
        playerDataController.ModifiedAttackPower = () => { return attackPowerToModify * Multiplier; };
        StartCoroutine(SkillDurationCoroutine(playerDataController));
    }

    protected override IEnumerator SkillDurationCoroutine(PlayerDataController playerDataController)
    {
        yield return new WaitForSeconds(Duration);
        playerDataController.ModifiedAttackPower = null;
    }
}
