using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static int Level { get; private set; } = 1;

    [SerializeField]
    private int currentExp = 0;
    [SerializeField]
    private int expToLevelUp = 3;
    private float levelProgressionMultiplier = 2.5f;

    public static event Action<float> OnExperienceChanged;
    public static event Action<int> OnLevelChanged;
    public static event Action OnLevelUpReady;

    private void Awake()
    {
        EnemySpawner.OnEnemyDeath += (go) => AddExperience();
        EnemySpawner.OnBossDissapeared += LevelDown;
        EnemySpawner.OnBossDefeated += LevelUp;
    }

    public void AddExperience()
    {
        if (currentExp >= expToLevelUp) return;

        currentExp++;
        OnExperienceChanged?.Invoke((float)currentExp / expToLevelUp);

        if (currentExp >= expToLevelUp)
            OnLevelUpReady?.Invoke();
    }

    public void LevelUp()
    {
        Level++;
        expToLevelUp = Mathf.RoundToInt((float)expToLevelUp * levelProgressionMultiplier);
        currentExp = 0;
        OnLevelChanged?.Invoke(Level);
    }

    public void LevelDown()
    {
        if(Level > 1)
        {
            Level--;
            expToLevelUp = Mathf.RoundToInt((float)expToLevelUp / levelProgressionMultiplier);
        }

        currentExp = 0;
        OnLevelChanged?.Invoke(Level);
        OnExperienceChanged?.Invoke(0f);
    }
}
