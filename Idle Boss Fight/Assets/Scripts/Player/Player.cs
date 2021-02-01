using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public PlayerAttack playerAttack;
    [HideInInspector]
    public PlayerData playerData;
    [HideInInspector]
    public PlayerAnimation playerAnimation;

    public EnemyController enemyController;
    public Enemy enemyTarget;

    private void Awake()
    {
        enemyController.OnEnemySpawned += OnEnemySpawned;

        playerInput = GetComponent<PlayerInput>();
        playerAttack = GetComponent<PlayerAttack>();
        playerData = GetComponent<PlayerData>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        playerInput.OnPlayerInputPressed += playerAttack.OnPlayerInput;
    }



    private void OnEnemySpawned(GameObject enemyGameObject)
    {
        enemyTarget = enemyGameObject.GetComponent<Enemy>();
    }
}
