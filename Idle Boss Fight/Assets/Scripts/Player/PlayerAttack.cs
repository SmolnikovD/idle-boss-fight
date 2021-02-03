using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
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
            yield return new WaitForSeconds(playerData.AttackRate);
            Attack(playerData.ClickPower);
        }
    }

    public void OnPlayerInput()
    {
        Attack(playerData.AttackPower);
    }
}
