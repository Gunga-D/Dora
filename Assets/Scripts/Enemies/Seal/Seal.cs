using UnityEngine;

public class Seal : MeleeEnemy
{
    [SerializeField] private ParticleSystem _sealDeathPS;
    [SerializeField] private DamagePopupSpawner _sealDamageShower;
    [SerializeField] private Bar _sealBar;

    [SerializeField] private float _sealMaxHealth;
    [SerializeField] private float _sealDamage;
    [SerializeField] private float _sealMovingSpeed;
    [SerializeField] private int _sealCost;

    private void Start()
    {
        InitializeStats(_sealMaxHealth, _sealCost);
        InitializeBehaviors(new OneDirectionMovePattern(this.transform, Vector2.up, _sealMovingSpeed));
        InitializeFacilities(_sealBar, _sealDamageShower, _sealDeathPS);

        InitializeAttacker(_sealDamage);
        InitializeAttackerFacilities();
    }
}
