using UnityEngine;

public abstract class ElementModifier : ScriptableObject
{
    protected ElementModifier _next;

    public abstract void Initialize<T>(T element);

    public void Add(ElementModifier additional)
    {
        if (_next == null)
            _next = additional;

        _next.Add(additional);
    }

    public virtual void Handle() => _next?.Handle();
}
