using UnityEngine;

public class PointFollowingMovePattern : MovePattern
{
    private SpriteRenderer _spriteComponent;

    private Rigidbody2D _physicElement;
    private Vector3 _targetPosition;
    private float _speed;

    protected override void PatternRealizationMove()
    {
        _physicElement.MovePosition(_targetPosition + _physicElement.transform.position * _speed * Time.deltaTime);

        MoveExtensionMethods.Flip(_spriteComponent, _targetPosition - _physicElement.transform.position);
    }

    public override MovePattern Clone(params object[] transmitted)
    {
        return new PointFollowingMovePattern(_physicElement.transform, (Vector3)transmitted[0], (float)transmitted[1]);
    }

    public PointFollowingMovePattern(Transform element, Vector3 targetPosition, float speed)
    {
        _speed = speed;
        _physicElement = ExtensionMethods.TryToFindComponent<Rigidbody2D>(element);
        _targetPosition = targetPosition;

        SpriteRenderer _spriteComponent = ExtensionMethods.TryToFindComponent<SpriteRenderer>(element);
    }
}
