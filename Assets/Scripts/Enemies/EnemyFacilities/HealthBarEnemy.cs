using UnityEngine;

public class HealthBarEnemy : Bar
{
    [SerializeField] private Transform _fillArea;

    public override void UpdateValue(float percent)
    {
        _fillArea.localScale = new Vector3(_fillArea.localScale.x * percent, _fillArea.localScale.y, _fillArea.localScale.z);
    }
}
