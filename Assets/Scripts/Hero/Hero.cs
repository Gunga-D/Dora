using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hero : Creature
{
    [SerializeField] private float _heroMaxHealth;

    [SerializeField] private Bar _healthBar;
    [SerializeField] private Bar _fireRateBar;
    [SerializeField] private MoneyCounter _moneyCounter;

    [SerializeField] private Bank _storage;
    [SerializeField] private WeaponHolder _holder;

    private Weapon _currentWeapon;
    private Camera mainCamera;

    public Action ReloadedTheGame;

    private void Start()
    {
        mainCamera = Camera.main;

        InitializeBasicStats(_heroMaxHealth);
    }

    private void Flip()
    {
        if(transform.position.x > mainCamera.ScreenToWorldPoint(Input.mousePosition).x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Update()
    {
        Flip();

        if (_holder.IsHold())
        {
            _currentWeapon = _holder.GetHoldingItem();

            _currentWeapon.Aim(mainCamera.ScreenToWorldPoint(Input.mousePosition), transform.rotation.eulerAngles.y);

            _fireRateBar.UpdateValue(_currentWeapon.fireRatePercent);

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _currentWeapon.Shoot(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        _moneyCounter.UpdateValue(_storage.GetBalance());
    }

    protected override void Die()
    {
        ReloadedTheGame?.Invoke();

        Reincarnate();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        _healthBar.UpdateValue(_healthPercent);
    }
}
