[System.Serializable]
public class SkillData : ISaveable
{
    public float multiplier = 2f;
    public float duration = 5f;
    public float cooldown = 30f;
    public bool isUnlocked = false;
}
