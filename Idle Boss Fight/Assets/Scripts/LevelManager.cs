using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Slider levelProgressBar;

    public int Level { get; set; } = 1;
    private int currentExp = 0;
    private int expToLevelUp = 15;

    public void AddExperience()
    {
        if (currentExp >= expToLevelUp) return;

        currentExp++;
        levelProgressBar.value = (float)currentExp / expToLevelUp;
    }

    public void LevelUp()
    {
        Level++;
        levelText.SetText(Level.ToString());
        levelProgressBar.value = 0;
        expToLevelUp = (int)(expToLevelUp * 1.8f);
        currentExp = 0;
    }
}
