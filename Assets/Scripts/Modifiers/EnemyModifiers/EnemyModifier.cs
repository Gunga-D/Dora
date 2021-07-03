public class EnemyModifier : ElementModifier
{
    protected Enemy _creature;

    public override void Initialize<T>(T element)
    {
        _creature = (Enemy)(object)element;
    }
}
