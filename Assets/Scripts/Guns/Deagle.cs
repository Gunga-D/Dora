using UnityEngine;

public class Deagle : Weapon
{
    [SerializeField] private float _deagleFireRate;
    [SerializeField] private int _deagleProjectileNumbers;
    [SerializeField] private float _deagleProjectileSpread;

    [SerializeField] private Transform _deagleTip;
    [SerializeField] private Projectile _deagleProjectileType;

    [SerializeField] private Animator _deagleAnimator;

    private void Start()
    {
        InitializeStats(_deagleFireRate, _deagleProjectileNumbers, _deagleProjectileSpread);
        InitializeMainElements(_deagleTip, _deagleProjectileType);
        InitializeFacilities(_deagleAnimator, Camera.main.GetComponent<CameraShaker>());
    }
}
