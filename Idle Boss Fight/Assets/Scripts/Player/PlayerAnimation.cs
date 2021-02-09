using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    Action SetRandomAnimation;

    private const string Attack1 = "Attack1";
    private const string Attack2 = "Attack2";
    private const string Idle = "Idle";
    private const string Dizzy = "Dizzy";

    private void Start()
    {
        StartCoroutine(RandomAttackAnimationCoroutine());
    }

    private IEnumerator RandomAttackAnimationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SetRandomAnimation = UnityEngine.Random.Range(0, 2) == 0 ? new Action(SetAttack1Animation) : new Action(SetAttack2Animation);
            SetRandomAnimation.Invoke();
        }
    }


    public void SetAttack1Animation()
    {
        playerAnimator.SetTrigger(Attack1);
    }

    public void SetAttack2Animation()
    {
        playerAnimator.SetTrigger(Attack2);
    }

    public void SetIdleAnimation()
    {
        playerAnimator.SetTrigger(Idle);
    }

    public void SetDizzyAnimation()
    {
        playerAnimator.SetTrigger(Dizzy);
    }

}
