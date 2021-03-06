﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossButtonUI : MonoBehaviour
{
    [SerializeField]
    private LevelSystem levelSystem;
    [SerializeField]
    private Button bossFightButton;

    public static event Action OnFightBossButtonPressed;

    private void Awake()
    {
        LevelSystem.OnLevelUpReady += () => SetFightBossButton(true);
        bossFightButton.onClick.AddListener(() =>
        {
            OnFightBossButtonPressed.Invoke();
            SetFightBossButton(false);
        });
    }

    private void Start()
    {
        SetFightBossButton(levelSystem.CurrentExp == levelSystem.ExpToLevelUp);
    }

    public void SetFightBossButton(bool value)
    {
        bossFightButton.gameObject.SetActive(value);
    }
}
