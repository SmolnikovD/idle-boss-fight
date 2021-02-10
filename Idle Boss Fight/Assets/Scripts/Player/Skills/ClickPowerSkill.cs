using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPowerSkill : Skill
{
    public override void Perform(PlayerDataController playerDataController)
    {
        float clickPowerToModify = playerDataController.GetStat(UpgradeType.StatsClickPower);
        playerDataController.ModifiedClickPower = () => { return clickPowerToModify * Multiplier; };
        StartCoroutine(SkillDurationCoroutine(playerDataController));
    }

    protected override IEnumerator SkillDurationCoroutine(PlayerDataController playerDataController)
    {
        yield return new WaitForSeconds(Duration);
        playerDataController.ModifiedClickPower = null;
    }
}
