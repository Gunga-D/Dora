using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    private float _damage;

    private void Attack(Creature entityTo)
    {
        entityTo.TakeDamage(_damage);
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        var hero = coll.transform.GetComponent<Hero>();

        if (hero)
        {
            Attack(hero);
        }
    }

    protected void InitializeAttacker(float damage)
    {
        _damage = damage;
    }

    protected void InitializeAttackerFacilities()
    {
    }

    public void ModifyDamage(float factor)
    {
        _damage *= factor;
    }
}
