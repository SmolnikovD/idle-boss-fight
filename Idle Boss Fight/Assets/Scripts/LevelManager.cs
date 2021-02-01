using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO Вынести логику UI
public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Slider levelProgressBar;

    private static int level = 1;
    public static int Level
    {
        get { return level; }
    }
    public static int CurrentLevel { get; private set; }
    private int currentExp = 0;
    private int expToLevelUp = 3;

    public event Action OnLevelUpReady;

    public void AddExperience()
    {
        if (currentExp >= expToLevelUp) return;

        currentExp++;
        levelProgressBar.value = (float)currentExp / expToLevelUp;

        if (currentExp >= expToLevelUp)
            OnLevelUpReady?.Invoke();
    }

    public void LevelUp()
    {
        level++;
        expToLevelUp = Mathf.RoundToInt((float)expToLevelUp * 1.8f);
        LevelReset();
    }

    public void LevelDown()
    {
        level--;
        expToLevelUp = Mathf.RoundToInt((float)expToLevelUp / 1.8f);
        LevelReset();
    }

    private void LevelReset()
    {
        levelText.SetText(Level.ToString());
        levelProgressBar.value = 0;
        currentExp = 0;
    }
}
