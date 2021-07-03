using UnityEngine;

public static class MoveExtensionMethods
{
    public static void Flip(SpriteRenderer gameObject, Vector2 direction)
    {
        if(direction.x > 0)
        {
            gameObject.flipX = false;
        }
        if (direction.y < 0)
        {
            gameObject.flipX = true;
        }

        if(direction.y > 0)
        {
            gameObject.flipY = false;
        }
        if(direction.y < 0)
        {
            gameObject.flipY = true;
        }
    }
}
