using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanelUI : MonoBehaviour
{
    [SerializeField]
    private ShopUI shopUI;
    [SerializeField]
    private Button shopButton;
    [SerializeField]
    private Button skillAttackPowerButton;
    [SerializeField]
    private Button skillClickPowerButton;
    [SerializeField]
    private Button skillAttackRateButton;

    private void Awake()
    {
        shopButton.onClick.AddListener(shopUI.ToggleShop);
    }
}
