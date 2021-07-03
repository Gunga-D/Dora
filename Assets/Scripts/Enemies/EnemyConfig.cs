using UnityEngine;

public abstract class EnemyConfig : ScriptableObject
{
    public abstract Enemy Prefab { get; }
    public abstract int EnemyDifficulty { get; }
}
