using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRateSkill : Skill
{
    public override void Perform(PlayerDataController playerDataController)
    {
        float attackRateToModify = playerDataController.GetStat(UpgradeType.StatsAttackRate);
        playerDataController.ModifiedAttackRate = () => { return attackRateToModify * Multiplier; };
        StartCoroutine(SkillDurationCoroutine(playerDataController));
    }

    protected override IEnumerator SkillDurationCoroutine(PlayerDataController playerDataController)
    {
        yield return new WaitForSeconds(Duration);
        playerDataController.ModifiedAttackRate = null;
    }
}
