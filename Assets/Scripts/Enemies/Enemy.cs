using System;
using UnityEngine;

public abstract class Enemy : Creature
{
    private int _cost;

    private IMovable _movingType;

    private Bar _healthBar;
    private DamagePopupSpawner _damageShower;
    private ParticleSystem _deathPS;
    private ParticleSystem _movingPS;

    public event Action<Enemy> RemovedFromGameBoard;

    public int Cost
    {
        get
        {
            return _cost;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movingType.Move();
    }

    protected void InitializeStats(float maxHealth, int cost)
    {
        InitializeBasicStats(maxHealth);

        _cost = cost;
    }

    protected void InitializeFacilities(Bar healthBar, DamagePopupSpawner damageShower, ParticleSystem deathPS)
    {
        _healthBar = healthBar;
        _damageShower = damageShower;
        _deathPS = deathPS;
    }

    protected void InitializeBehaviors(IMovable movingType)
    {
        _movingType = movingType;
    }

    protected override void Die()
    {
        RemovedFromGameBoard?.Invoke(this);

        ParticleSystem deathPS = Instantiate(_deathPS, transform.position, Quaternion.identity);
        Destroy(deathPS.gameObject, deathPS.main.duration);

        Destroy(this.gameObject);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        _healthBar.UpdateValue(_healthPercent);
        _damageShower.Spawn(transform.position, damage);
    }
}
