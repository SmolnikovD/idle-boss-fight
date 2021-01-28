using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action OnPlayerInputPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPlayerInputPressed?.Invoke();
        }
    }
}
