using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public bool IsUnlocked { get; set; } = false;
    public float Duration { get; set; } = 1f;
    public float Cooldown { get; set; } = 30f;

    protected Skill(float duration, float cooldown)
    {
        Duration = duration;
        Cooldown = cooldown;
    }

    public abstract void Perform();
    public abstract void Upgrade();
}
