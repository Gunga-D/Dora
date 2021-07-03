using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private MovePattern _movingType;

    private ParticleSystem _destroyEffect;

    private float _lifeTime;
    private float _flightTime;

    private IEnumerator StartFlying()
    {
        _flightTime = 0;

        while (_flightTime < _lifeTime)
        {
            _movingType.Move();

            _flightTime += 0.1f;

            yield return null;
        }

        if (this.gameObject)
        {
            Destroy(this.gameObject);

            ParticleSystem destroyEffect = Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            Destroy(destroyEffect.gameObject, destroyEffect.main.duration);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        CollisionReaction(coll.transform, _flightTime);
    }

    protected void InitializeBehaviors(MovePattern movingType)
    {
        _movingType = movingType;
    }

    protected void InitializeFacilities(ParticleSystem destroyEffect)
    {
        _destroyEffect = destroyEffect;
    }

    protected void InitializeStats(float lifeTime)
    {
        _lifeTime = lifeTime;
    }

    protected abstract void CollisionReaction(Transform reactingTo, float lifeTime);

    public virtual void Launch(Vector3 direction)
    {
        StartCoroutine(StartFlying());
    }
}
