using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonsUI : MonoBehaviour
{
    [SerializeField]
    private Button SkillAttackPowerButton;
    [SerializeField]
    private Button SkillClickPowerButton;
    [SerializeField]
    private Button SkillClickRateButton;

    public event Action OnSkillAttackPowerButtonClicked;
    public event Action OnSkillClickPowerButtonClicked;
    public event Action OnSkillClickRateButtonClicked;

    private void Awake()
    {
        SkillAttackPowerButton.onClick.AddListener(() => OnSkillAttackPowerButtonClicked?.Invoke());
        SkillClickPowerButton.onClick.AddListener(() => OnSkillClickPowerButtonClicked?.Invoke());
        SkillClickRateButton.onClick.AddListener(() => OnSkillClickRateButtonClicked?.Invoke());
    }
}
