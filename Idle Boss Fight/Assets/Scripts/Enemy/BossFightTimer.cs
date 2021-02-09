using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightTimer : MonoBehaviour
{
    [SerializeField]
    public float time;
    [SerializeField]
    private BossTimerUI timerUI;

    public void StartBossFightTimer(Action onTimerEnd)
    {
        StartCoroutine(BossFightTimerCoroutine(onTimerEnd));
        timerUI.SetTotalTime(time);
    }

    private IEnumerator BossFightTimerCoroutine(Action onTimerEnd)
    {
        yield return new WaitForSeconds(time);
        onTimerEnd?.Invoke();
    }
}
