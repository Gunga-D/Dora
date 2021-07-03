using UnityEngine;

public class OneDirectionMovePattern : MovePattern
{
    private Rigidbody2D _physicElement;
    private Vector2 _direction;
    private float _speed;

    protected override void PatternRealizationMove()
    {
        _physicElement.MovePosition((Vector2)_physicElement.transform.position + (_direction * _speed * Time.deltaTime));
    }

    public override MovePattern Clone(params object[] transmitted)
    {
        return new OneDirectionMovePattern(_physicElement.transform, (Vector2)transmitted[0], (float)transmitted[1]);
    }

    public OneDirectionMovePattern(Transform element, Vector2 direction, float speed)
    {
        _speed = speed;
        _physicElement = ExtensionMethods.TryToFindComponent<Rigidbody2D>(element);
        _direction = direction.normalized;

        SpriteRenderer spriteComponent = ExtensionMethods.TryToFindComponent<SpriteRenderer>(element);
        MoveExtensionMethods.Flip(spriteComponent, _direction);
    }
}
