using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public LevelSystem levelManager;
    public EnemyController enemyController;
    public UIController uiController;
    public CurrencySystem currencySystem;

    private void OnEnable()
    {
        enemyController.OnEnemyDeath += levelManager.AddExperience;
        enemyController.OnEnemyDeath += () => currencySystem.AddCoins(enemyController.CurrentEnemy.GetComponent<Enemy>().coinsReward, LevelSystem.Level, () => uiController.UpdateCoinsUI(currencySystem.Coins)); // pzdc
        enemyController.OnBossDefeated += levelManager.LevelUp;
        enemyController.OnBossFightTimerEnded += levelManager.LevelDown;
        uiController.OnFightBossButtonPressed += enemyController.PrepareBossFight;
        levelManager.OnLevelUpReady += () => uiController.SetFightBossButton(true);
    }  
}
