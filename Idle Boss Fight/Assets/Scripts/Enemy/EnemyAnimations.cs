using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private const string DEATH = "Death";

    public void SetDeathAnimation()
    {
        animator.SetTrigger(DEATH);
    }
}
