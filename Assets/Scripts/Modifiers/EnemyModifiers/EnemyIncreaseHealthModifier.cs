using UnityEngine;

[CreateAssetMenu(fileName = "EnemyIncreaseHealthModifier")]
public class EnemyIncreaseHealthModifier : EnemyModifier
{
    [SerializeField] private float _healthFactor;

    public override void Handle()
    {
        _creature.ModifyHealth(_healthFactor);
    }
}
