using UnityEngine;

[CreateAssetMenu(fileName = "SealConfig")]
public class SealConfig : EnemyConfig
{
    [SerializeField] private int _enemyDifficulty;
    [SerializeField] private Seal _prefab;

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
