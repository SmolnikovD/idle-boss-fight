using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public float AttackPower { get; set; } = 1;
    [field: SerializeField]
    public float ClickPower { get; set; } = 1;
    [field: SerializeField]
    public float AttackRate { get; set; } = 1;

}
