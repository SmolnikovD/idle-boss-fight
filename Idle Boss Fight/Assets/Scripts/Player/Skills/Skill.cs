using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    public Image cooldownImage;
    public Button skillButton;

    protected SkillData skillData = new SkillData();

    public float Multiplier { get => skillData.multiplier; protected set => skillData.multiplier = value; }
    public float Duration { get => skillData.duration; protected set => skillData.duration = value; }
    public float Cooldown { get => skillData.cooldown; protected set => skillData.cooldown = value; }

    public bool IsUnlocked { get => skillData.isUnlocked; protected set => skillData.isUnlocked = value; }
    public bool IsPerforming { get; set; } = false;

    protected abstract string SAVE_DATA_ID { get; }

    protected virtual void Awake()
    {
        skillData = SaveSystem.Load(skillData, SAVE_DATA_ID);
    }

    protected void Start()
    {
        if (IsUnlocked) Unlock();
    }

    public abstract void Perform(PlayerDataController playerDataController);

    protected virtual IEnumerator SkillDurationCoroutine(PlayerDataController playerDataController)
    {
        yield return new WaitForSeconds(skillData.duration);
    }

    public virtual void Upgrade()
    {
        skillData.multiplier += 1f;
        skillData.duration += 1f;
        skillData.cooldown -= 1f;
    }

    public virtual void Unlock()
    {
        skillData.isUnlocked = true;

        Color fullColor = cooldownImage.color;
        fullColor.a = 1f;
        cooldownImage.color = fullColor;

        fullColor = skillButton.image.color;
        fullColor.a = 1f;
        skillButton.image.color = fullColor;

        skillButton.interactable = true;
    }

    protected virtual void OnDisable()
    {
        SaveSystem.Save(skillData, SAVE_DATA_ID);
    }
}
