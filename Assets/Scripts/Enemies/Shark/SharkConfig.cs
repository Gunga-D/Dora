using UnityEngine;

[CreateAssetMenu(fileName = "SharkConfig")]
public class SharkConfig : EnemyConfig
{
    [SerializeField] private int _enemyDifficulty;
    [SerializeField] private Shark _prefab;

    public override int EnemyDifficulty
    {
        get
        {
            return _enemyDifficulty;
        }
    }

    public override Enemy Prefab
    {
        get
        {
            return _prefab;
        }
    }
}
