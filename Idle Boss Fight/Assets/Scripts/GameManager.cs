using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public LevelManager levelManager;
    public EnemySpawner enemySpawner;

    private void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }

    private void OnEnable()
    {
        enemySpawner.OnEnemyDeath += levelManager.AddExperience;
    }
    
}
