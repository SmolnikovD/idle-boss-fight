using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO Вынести логику UI
public class LevelSystem : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Slider levelProgressBar;

    public static int Level { get; private set; } = 1;

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
        Level++;
        expToLevelUp = Mathf.RoundToInt((float)expToLevelUp * 1.8f);
        LevelReset();
    }

    public void LevelDown()
    {
        Level--;
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
