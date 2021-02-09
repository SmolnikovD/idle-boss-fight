using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public int AttackPower { get; set; } = 1;
    [field: SerializeField]
    public int ClickPower { get; set; } = 1;
    [field: SerializeField]
    public float AttackRate { get; set; } = 1f;

}
