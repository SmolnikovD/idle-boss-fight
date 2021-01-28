using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public PlayerInput playerInput;
    public PlayerAttack playerAttack;
    public PlayerData playerData;

    public EnemySpawner enemySpawner;
    public Enemy enemyTarget;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAttack = GetComponent<PlayerAttack>();
        playerData = GetComponent<PlayerData>();
    }

    private void OnEnable()
    {
        playerInput.OnPlayerInputPressed += playerAttack.OnPlayerInput;
        enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }

    private void OnEnemySpawned(GameObject enemyGameObject)
    {
        enemyTarget = enemyGameObject.GetComponent<Enemy>();
    }
}
