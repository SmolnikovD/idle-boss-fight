using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private Slider levelProgressBar;

    private void Awake()
    {
        LevelSystem.OnExperienceChanged += OnExperienceChanged;
        LevelSystem.OnLevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        levelText.SetText(level.ToString());
    }

    private void OnExperienceChanged(float levelPercent)
    {
        levelProgressBar.value = levelPercent;
    }
}
