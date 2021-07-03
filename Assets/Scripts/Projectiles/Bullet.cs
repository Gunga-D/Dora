using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private ParticleSystem _bulletDestroyEffect;

    [SerializeField] private int _bulletLifeTime;

    [SerializeField] private float _maxDamage;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _reducedDamagePerPeriod;
    [SerializeField] private float _speed;

    private void RotateToDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    protected override void CollisionReaction(Transform reactingTo, float flightTime) { 
        var enemy = reactingTo.GetComponent<Enemy>();

        if (enemy)
        {
            float damage = _maxDamage - _reducedDamagePerPeriod * flightTime;
            if(damage < _minDamage)
            {
                damage = _minDamage;
            }

            enemy.TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }

    public override void Launch(Vector3 direction)
    {
        RotateToDirection(direction);

        InitializeStats(_bulletLifeTime);
        InitializeBehaviors(new OneDirectionMovePattern(this.transform, direction, _speed));
        InitializeFacilities(_bulletDestroyEffect);

        base.Launch(direction);
    }
}
