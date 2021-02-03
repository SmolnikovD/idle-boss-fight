using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [HideInInspector]
    public PlayerAnimation playerAnimation;

    public EnemyController enemyController;
    public Enemy enemyTarget;

    private void Awake()
    {
        EnemySpawner.OnEnemySpawned += OnEnemySpawned;
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnemySpawned(GameObject enemyGameObject)
    {
        enemyTarget = enemyGameObject.GetComponent<Enemy>();
    }
}
