using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    protected override void Start()
    {
        Health = maxHealth;
        enemyUI.InitializeEnemyUI("Boss", maxHealth);
    }
}
