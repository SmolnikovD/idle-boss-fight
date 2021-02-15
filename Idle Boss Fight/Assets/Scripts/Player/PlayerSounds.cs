using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip attackSound;

    public void PlayAttackSound() => AudioPlayer.Instance.Play(attackSound);
}
