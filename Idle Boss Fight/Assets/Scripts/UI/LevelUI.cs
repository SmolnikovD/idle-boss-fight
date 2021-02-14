using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    private LevelSystem levelSystem;

    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private Slider levelProgressBar;

    private void Awake()
    {
        LevelSystem.OnExperienceChanged += UpdateExperienceUI;
        LevelSystem.OnLevelChanged += UpdateLevelUI;
    }

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        UpdateLevelUI();
        UpdateExperienceUI();
    }

    private void UpdateLevelUI()
    {
        levelText.SetText(LevelSystem.Level.ToString());
    }

    private void UpdateExperienceUI()
    {
        float levelPercent = (float)levelSystem.CurrentExp / levelSystem.ExpToLevelUp;
        levelProgressBar.value = levelPercent;
    }
}
