using UnityEngine;

public class Shark : MeleeEnemy
{
    [SerializeField] private ParticleSystem _sharkDeathPS;
    [SerializeField] private DamagePopupSpawner _sharkDamageShower;
    [SerializeField] private Bar _sharkBar;

    [SerializeField] private float _sharkMaxHealth;
    [SerializeField] private float _sharkDamage;
    [SerializeField] private float _sharkMovingSpeed;
    [SerializeField] private int _sharkCost;

    private void Start()
    {
        InitializeStats(_sharkMaxHealth, _sharkCost);
        InitializeBehaviors(new OneDirectionMovePattern(this.transform, Vector2.up, _sharkMovingSpeed));
        InitializeFacilities(_sharkBar, _sharkDamageShower, _sharkDeathPS);

        InitializeAttacker(_sharkDamage);
        InitializeAttackerFacilities();
    }
}
