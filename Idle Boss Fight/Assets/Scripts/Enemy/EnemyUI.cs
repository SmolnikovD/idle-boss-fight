using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private TextMeshProUGUI enemyName;
    [SerializeField]
    private TextMeshProUGUI enemyCurrentHealth;

    private int maxHealth;

    public void InitializeEnemyUI(string name, int health)
    {
        enemyName.SetText(name);
        enemyCurrentHealth.SetText(health.ToString() + " HP");
        this.maxHealth = health;
    }

    public void UpdateHealthBarUI(int healthToDisplay)
    {
        enemyCurrentHealth.SetText(healthToDisplay.ToString() + " HP");
        healthBar.value = (float)healthToDisplay / maxHealth;
    }
}
