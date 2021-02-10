using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerDataController playerDataController;
    public static event Action<int> OnPlayerAttack;

    private void Awake()
    {
        PlayerInput.OnPlayerInputPressed += OnPlayerInput;
    }

    private void Start()
    {
        StartCoroutine(IdleAttack());
    }

    public void Attack(int damage)
    {
        OnPlayerAttack?.Invoke(damage);
    }

    private IEnumerator IdleAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(playerDataController.GetStat(UpgradeType.StatsAttackRate));
            Attack((int)playerDataController.GetStat(UpgradeType.StatsClickPower));
        }
    }

    public void OnPlayerInput()
    {
        Attack((int)playerDataController.GetStat(UpgradeType.StatsAttackPower));
    }
}
