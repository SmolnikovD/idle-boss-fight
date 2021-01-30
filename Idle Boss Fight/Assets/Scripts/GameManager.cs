using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public LevelManager levelManager;
    public EnemyController enemyController;
    public UIController uiController;

    private void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }

    private void OnEnable()
    {
        enemyController.OnEnemyDeath += levelManager.AddExperience;
        enemyController.OnBossDefeated += levelManager.LevelUp;
        enemyController.OnBossFightTimerEnded += levelManager.LevelDown;
        uiController.OnFightBossButtonPressed += enemyController.PrepareBossFight;
        levelManager.OnLevelUpReady += () => uiController.SetFightBossButton(true);
    }  
}
