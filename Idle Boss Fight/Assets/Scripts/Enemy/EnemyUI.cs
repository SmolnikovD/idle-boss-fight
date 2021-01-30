using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public string enemyName;

    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private TextMeshProUGUI enemyNameText;
    [SerializeField]
    private TextMeshProUGUI enemyCurrentHealth;

    private int maxHealth;

    public void InitializeEnemyUI(int health)
    {
        enemyNameText.SetText(enemyName);
        enemyCurrentHealth.SetText(health.ToString() + " HP");
        this.maxHealth = health;
    }

    public void UpdateHealthBarUI(int healthToDisplay)
    {
        enemyCurrentHealth.SetText(healthToDisplay.ToString() + " HP");
        healthBar.value = (float)healthToDisplay / maxHealth;
    }
}
