using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimerUI : MonoBehaviour
{
    public float BossTime { get; set; }
    private float currentTime;

    private Slider timerSlider;

    private void Start()
    {
        timerSlider = GetComponent<Slider>();
        timerSlider.value = 1f;
        currentTime = BossTime;
    }

    void Update()
    {
        CalculateBossTimer();
    }

    private void CalculateBossTimer()
    {
        currentTime -= Time.deltaTime;
        timerSlider.value = currentTime / BossTime;
    }
}
