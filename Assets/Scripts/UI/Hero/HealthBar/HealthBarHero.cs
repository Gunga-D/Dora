using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarHero : Bar
{
    [SerializeField] private List<Image> _health;

    private void Reincarnate()
    {
        for(int index = 0; index < _health.Count; index++)
        {
            _health[index].color = new Color(255, 255, 255, 255);
        }
    }

    public override void UpdateValue(float percent)
    {
        if(percent == 1)
        {
            Reincarnate();
            return;
        }

        int index = Mathf.RoundToInt(_health.Count * percent);
        if (index < _health.Count)
        {
            _health[index].color = new Color(255, 255, 255, 0);
        }
    }
}
