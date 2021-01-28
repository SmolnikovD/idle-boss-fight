using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        StartCoroutine(IdleAttack());
    }

    public void Attack()
    {
        player.enemyTarget.GetDamage(player.playerData.Damage);
    }

    private IEnumerator IdleAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(player.playerData.AttackRate);
            Attack();
        }
    }

    public void OnPlayerInput()
    {
        Attack();
    }
}
