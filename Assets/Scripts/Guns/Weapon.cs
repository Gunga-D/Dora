using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float _fireRate;
    private int _projectileNumber;
    private float _projectileSpread;

    private Projectile _projectileType;
    private Transform _tip;

    private Animator _animator;
    private CameraShaker _cameraShaker;

    private float _distanceIncrease;
    private float _timer = 0;

    public float fireRatePercent
    {
        get
        {
            float percent = _timer / _fireRate;

            if (percent > 1)
            {
                return 1;
            }

            return percent;
        }
    }

    private void Update()
    {
        _timer += 0.1f;
    }

    protected void InitializeStats(float fireRate, int projectilesNumber, float projectileSpread)
    {
        _fireRate = fireRate;
        _projectileNumber = projectilesNumber;
        _projectileSpread = projectileSpread;

        _distanceIncrease = _projectileSpread / 2;
    }

    protected void InitializeMainElements(Transform tip, Projectile projectileType)
    {
        _tip = tip;
        _projectileType = projectileType;
    }

    protected void InitializeFacilities(Animator animator, CameraShaker cameraShaker)
    {
        _animator = animator;
        _cameraShaker = cameraShaker;
    }

    public void Aim(Vector3 pointTo, float playerRotationY)
    {
        Vector3 difference = pointTo - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90f || rotationZ > 90)
        {
            if(playerRotationY == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }else if(playerRotationY == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }

    public void Shoot(Vector3 pointTo)
    {
        if (fireRatePercent >= 1)
        {
            _timer = 0;

            Vector3 rightDirection = pointTo - _tip.position;

            for (int i = 0; i < _projectileNumber; i++)
            {
                Projectile instance = Instantiate(_projectileType, _tip.position, Quaternion.identity);

                Vector3 direction = (Vector3.Cross(transform.forward, rightDirection).normalized * Mathf.Pow(-1f, i) * _distanceIncrease * Mathf.CeilToInt((float)i / 2) + pointTo) - _tip.position;
                Debug.DrawLine(_tip.position, (Vector3.Cross(transform.forward, rightDirection).normalized * Mathf.Pow(-1f, i) * _distanceIncrease * Mathf.CeilToInt((float)i / 2) + pointTo), Color.blue, 5f);
                instance.Launch(direction.normalized);
            }

            _cameraShaker.StartEffect(0.01f, 0.15f, 0.2f);

            _animator.SetTrigger("Shoot");
        }
    }
}
