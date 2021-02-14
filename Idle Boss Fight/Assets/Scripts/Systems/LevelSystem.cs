using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private LevelData levelData = new LevelData();

    public static int Level { get; private set; } = 1;
    public int CurrentExp { get => levelData.currentExp; }
    public int ExpToLevelUp { get => levelData.expToLevelUp; }

    private const float LEVEL_PROGRESSION_MULTIPLIER = 2.5f;

    public static event Action OnExperienceChanged;
    public static event Action OnLevelChanged;
    public static event Action OnLevelUpReady;

    private void Awake()
    {
        levelData = SaveSystem.Load(levelData);
        Level = levelData.level;

        EnemySpawner.OnEnemyDeath += (go) => AddExperience();
        EnemySpawner.OnBossDissapeared += LevelDown;
        EnemySpawner.OnBossDefeated += LevelUp;
    }

    public void AddExperience()
    {
        if (levelData.currentExp >= levelData.expToLevelUp) return;

        levelData.currentExp++;
        OnExperienceChanged?.Invoke();

        if (levelData.currentExp >= levelData.expToLevelUp)
            OnLevelUpReady?.Invoke();
    }

    public void LevelUp()
    {
        Level++;
        levelData.expToLevelUp = Mathf.RoundToInt(levelData.expToLevelUp * LEVEL_PROGRESSION_MULTIPLIER);
        levelData.currentExp = 0;
        OnLevelChanged?.Invoke();
    }

    public void LevelDown()
    {
        if(Level > 1)
        {
            Level--;
            levelData.expToLevelUp = Mathf.RoundToInt(levelData.expToLevelUp / LEVEL_PROGRESSION_MULTIPLIER);
        }

        levelData.currentExp = 0;
        OnLevelChanged?.Invoke();
        OnExperienceChanged?.Invoke();
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        levelData.level = Level;
        SaveSystem.Save(levelData);
    }
#endif

#if UNITY_ANDROID
    private void OnApplicationPause()
    {
        levelData.level = Level;
        SaveSystem.Save(levelData);
    }
#endif
}
