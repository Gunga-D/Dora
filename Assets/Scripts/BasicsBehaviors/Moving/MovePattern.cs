using UnityEngine;

public abstract class MovePattern : IMovable
{
    protected abstract void PatternRealizationMove();

    public void Move()
    {
        PatternRealizationMove();
    }

    public abstract MovePattern Clone(params object[] transmitted);
}
