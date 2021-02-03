using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private bool isOpened = false;

    private void Awake()
    {
        CloseShop();
    }

    public void ToggleShop()
    {
        if (isOpened) CloseShop();
        else OpenShop();

        isOpened = !isOpened;
    }

    private void OpenShop()
    {
        animator.ResetTrigger("CloseShop");
        animator.SetTrigger("OpenShop");
    }

    private void CloseShop()
    {
        animator.ResetTrigger("OpenShop");
        animator.SetTrigger("CloseShop");
    }
}
