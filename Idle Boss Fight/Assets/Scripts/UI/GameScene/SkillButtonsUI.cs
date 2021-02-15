using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonsUI : MonoBehaviour
{
    [Header("Skills Buttons")]
    [SerializeField]
    private Button skillAttackPowerButton;
    [SerializeField]
    private Button skillClickPowerButton;
    [SerializeField]
    private Button skillClickRateButton;

    public event Action OnSkillAttackPowerButtonClicked;
    public event Action OnSkillClickPowerButtonClicked;
    public event Action OnSkillClickRateButtonClicked;

    private const float SMOOTH_STEP = 0.05f;

    private void Awake()
    {
        skillAttackPowerButton.onClick.AddListener(() => OnSkillAttackPowerButtonClicked?.Invoke());
        skillClickPowerButton.onClick.AddListener(() => OnSkillClickPowerButtonClicked?.Invoke());
        skillClickRateButton.onClick.AddListener(() => OnSkillClickRateButtonClicked?.Invoke());
    }

    public void StartCooldownUIRoutine(Skill skill) => StartCoroutine(CooldownUIRoutine(skill));

    private IEnumerator CooldownUIRoutine(Skill skill)
    {
        skill.skillButton.interactable = false;

        float step = SMOOTH_STEP / skill.Duration;
        while (skill.cooldownImage.fillAmount > 0f)
        {
            skill.cooldownImage.fillAmount -= step;
            yield return new WaitForSeconds(SMOOTH_STEP);
        }

        step = SMOOTH_STEP / skill.Cooldown;
        while (skill.cooldownImage.fillAmount < 1f)
        {
            skill.cooldownImage.fillAmount += step;
            yield return new WaitForSeconds(SMOOTH_STEP);
        }

        skill.skillButton.interactable = true;
    }
}
