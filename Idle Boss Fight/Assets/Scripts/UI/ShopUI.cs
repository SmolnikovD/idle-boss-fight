using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject shopGameObject;
    private Animator animator;

    private bool isOpened = false;

    private void Awake()
    {
        animator = shopGameObject.GetComponent<Animator>();
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
