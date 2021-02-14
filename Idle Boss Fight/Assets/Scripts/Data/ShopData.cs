using System;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class ShopData : ISaveable
{
    public int statsAttackPowerCost = 10;
    public int statsClickPowerCost = 50;
    public int statsAttackRateCost = 100;
    public int skillAttackPowerCost = 200;
    public int skillClickPowerCost = 600;
    public int skillAttackRateCost = 1000;
}
