using UnityEngine;

public class EnemyPositionDisposer: MonoBehaviour
{
    [SerializeField] private float distaceBetween;
    private Vector3 _spawnAreaPosition;
    private Vector3 _spawnAreaScale;
    private Vector2 _currentIssuedPosition;
    private Vector2 _previousIssuedPosition;

    private void Start()
    {
        _previousIssuedPosition = Vector2.zero;

        _spawnAreaPosition = transform.position;
        _spawnAreaScale = transform.localScale;
    }

    public Vector2 GetFreePosition()
    {
        do
        {
            _currentIssuedPosition = new Vector2(_spawnAreaPosition.x + Random.Range(-_spawnAreaScale.x / 2, _spawnAreaScale.x / 2), _spawnAreaPosition.y);
        } while (_currentIssuedPosition.x - distaceBetween > _previousIssuedPosition.x && _currentIssuedPosition.x + distaceBetween < _previousIssuedPosition.x);

        _previousIssuedPosition = _currentIssuedPosition;

        return _currentIssuedPosition;
    }
}
