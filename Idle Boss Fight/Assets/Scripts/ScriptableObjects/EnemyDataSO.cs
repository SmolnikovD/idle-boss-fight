using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy/Data")]
public class EnemyDataSO : ScriptableObject
{
    public int enemyMaxHealth;
    public string enemyName;
}
