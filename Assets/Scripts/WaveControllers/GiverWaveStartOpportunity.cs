using System;
using UnityEngine;

public class GiverWaveStartOpportunity : MonoBehaviour
{
    [SerializeField] private StartWaveButtonHandler _tumbler;
    private Action _opportunityFor;

    public void SetOpportunityFor(Action func)
    {
        _opportunityFor = func;
        _tumbler.Operation += _opportunityFor;
    }

    public void OnDisableOpportunityFor()
    {
        _tumbler.Operation -= _opportunityFor;
    }

    public bool TryToGive(bool opportunityCondition)
    {
        if (opportunityCondition)
        {
            _tumbler.OnEnable();
            return true;
        }

        _tumbler.OnDisable();
        return false;
    }
}
