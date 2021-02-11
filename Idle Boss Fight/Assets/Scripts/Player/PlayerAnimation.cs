using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    Action SetRandomAnimation;

    private const string ATTACK_1 = "Attack1";
    private const string ATTACK_2 = "Attack2";
    private const string IDLE = "Idle";
    private const string DIZZY = "Dizzy";

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
        playerAnimator.SetTrigger(ATTACK_1);
    }

    public void SetAttack2Animation()
    {
        playerAnimator.SetTrigger(ATTACK_2);
    }

    public void SetIdleAnimation()
    {
        playerAnimator.SetTrigger(IDLE);
    }

    public void SetDizzyAnimation()
    {
        playerAnimator.SetTrigger(DIZZY);
    }

}
