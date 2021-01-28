using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Damage { get; set; } = 1;
    public float attackRate = 1f;

    private PlayerInput playerInput;

    public Enemy enemyTarget;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.OnPlayerInputPressed += OnPlayerInput;
    }

    private void Start()
    {
        StartCoroutine(DamageCoroutine());
    }

    public void DealDamage(Enemy target)
    {
        target.GetDamage(Damage);
    }

    private IEnumerator DamageCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            DealDamage(enemyTarget);
        }
    }

    private void OnPlayerInput()
    {
        DealDamage(enemyTarget);
    }
}
