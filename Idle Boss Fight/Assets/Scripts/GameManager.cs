using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public LevelManager levelManager;
    public EnemyController enemyController;

    private void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }

    private void OnEnable()
    {
        enemyController.OnEnemyDeath += levelManager.AddExperience;
        enemyController.OnBossDefeated += levelManager.LevelUp;
    }
    
}
