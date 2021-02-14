using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject shopGameObject;
    [SerializeField]
    private Button closeShopButton;
    private Animator animator;

    private bool isOpened = false;

    private void Awake()
    {
        closeShopButton.onClick.AddListener(CloseShop);
        animator = shopGameObject.GetComponent<Animator>();
    }

    public void ToggleShop()
    {
        if (isOpened) CloseShop();
        else OpenShop();
    }

    private void OpenShop()
    {
        animator.ResetTrigger("CloseShop");
        animator.SetTrigger("OpenShop");
        isOpened = true;
    }

    private void CloseShop()
    {
        animator.ResetTrigger("OpenShop");
        animator.SetTrigger("CloseShop");
        isOpened = false;
    }
}
