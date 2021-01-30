﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField]
    public float timer;

    public Action OnBossFightTimerEnded;

    public void StartBossFightTimer(Boss boss)
    {
        StartCoroutine(BossFightTimerCoroutine(boss));
    }

    private IEnumerator BossFightTimerCoroutine(Boss boss)
    {
        yield return new WaitForSeconds(timer);
        if (boss.Health > 0)
        {
            OnBossFightTimerEnded?.Invoke();
            boss.BossDissappeared();
        }
    }
}