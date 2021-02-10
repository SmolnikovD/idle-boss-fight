using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    protected Image cooldownImage;
    [SerializeField]
    protected Button skillButton;

    [field: SerializeField]
    public float Multiplier { get; protected set; } = 1f;
    [field: SerializeField]
    public float Duration { get; protected set; } = 1f;
    [field: SerializeField]
    public float Cooldown { get; protected set; } = 30f;

    public bool IsUnlocked { get; protected set; } = false;

    public abstract void Perform(PlayerDataController playerDataController);


    protected virtual IEnumerator SkillDurationCoroutine(PlayerDataController playerDataController)
    {
        yield return new WaitForSeconds(Duration);
    }

    public virtual void Upgrade()
    {
        Multiplier += 1f;
        Duration += 1f;
        Cooldown -= 1f;
    }

    public virtual void Unlock()
    {
        IsUnlocked = true;
        Color fullColor = cooldownImage.color;
        fullColor.a = 1f;
        cooldownImage.color = fullColor;
        skillButton.interactable = true;
    }
}
