using UnityEngine;

public class M590 : Weapon
{
    [SerializeField] private float _m590FireRate;
    [SerializeField] private int _m590ProjectileNumbers;
    [SerializeField] private float _m590ProjectileSpread;

    [SerializeField] private Transform _m590Tip;
    [SerializeField] private Projectile _m590ProjectileType;

    [SerializeField] private Animator _m590Animator;

    private void Start()
    {
        InitializeStats(_m590FireRate, _m590ProjectileNumbers, _m590ProjectileSpread);
        InitializeMainElements(_m590Tip, _m590ProjectileType);
        InitializeFacilities(_m590Animator, Camera.main.GetComponent<CameraShaker>());
    }
}
