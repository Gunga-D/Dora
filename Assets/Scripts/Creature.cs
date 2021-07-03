using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    protected float _health;
    protected float _maxHealth;

    protected float _healthPercent {
        get
        {
            return _health / _maxHealth;
        }
    }

    protected void InitializeBasicStats(float health){
        _maxHealth = health;
        _health = health;
    }

    protected void Reincarnate()
    {
        _health = _maxHealth;
    }

    protected abstract void Die();

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Die();
        }
    }

    public virtual void ModifyHealth(float factor)
    {
        _maxHealth *= factor;
    }
}
