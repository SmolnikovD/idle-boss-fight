using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField]
    private float timer;

    public Action OnBossFightTimerEnded;

    public void StartBossFightTimer()
    {
        StartCoroutine(BossFightTimerCoroutine());
        Debug.Log("TimeStarted");
    }

    private IEnumerator BossFightTimerCoroutine()
    {
        yield return new WaitForSeconds(timer);
        OnBossFightTimerEnded?.Invoke();
        Debug.Log("TimeEnded");
    }
}
