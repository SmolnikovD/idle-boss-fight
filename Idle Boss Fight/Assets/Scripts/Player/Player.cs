using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Damage { get; set; } = 1;
    public float attackRate = 1f;

    private PlayerInput playerInput;

    public EnemySpawner enemySpawner;
    private Enemy enemyTarget;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.OnPlayerInputPressed += OnPlayerInput;
        enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }

    private void Start()
    {
        StartCoroutine(IdleAttack());
    }

    public void Attack()
    {
        enemyTarget.GetDamage(Damage);
    }

    private IEnumerator IdleAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            Attack();
        }
    }

    private void OnPlayerInput()
    {
        Attack();
    }

    private void OnEnemySpawned(GameObject enemyGameObject)
    {
        enemyTarget = enemyGameObject.GetComponent<Enemy>();
    }
}
