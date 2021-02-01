using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    public Button fightBossButton;
    public TextMeshProUGUI coinsText;

    public event Action OnFightBossButtonPressed;

    private void Start()
    {
        SetFightBossButton(false);
    }
    
    public void SetFightBossButton(bool value)
    {
        fightBossButton.gameObject.SetActive(value);
    }

    public void OnFightBossButtonPressedCallback() => OnFightBossButtonPressed.Invoke();

    public void UpdateCoinsUI(int amount)
    {
        coinsText.SetText(amount.ToString());
    }
}
