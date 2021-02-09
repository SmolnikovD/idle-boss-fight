using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimerUI : MonoBehaviour
{
    [SerializeField]
    private Slider timerSlider;

    private float totalTime;
    private float currentTime;

    private void Start()
    {
        timerSlider.value = 1f;
        currentTime = totalTime;
    }

    public void SetTotalTime(float totalTime)
    {
        this.totalTime = totalTime;
    }

    void Update()
    {
        CalculateBossTimer();
    }

    private void CalculateBossTimer()
    {
        currentTime -= Time.deltaTime;
        timerSlider.value = currentTime / totalTime;
    }
}
