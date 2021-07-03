using System;
using UnityEngine.UI;
using UnityEngine;

public class StartWaveButtonHandler : MonoBehaviour
{
    public event Action Operation;
    [SerializeField] private Button _item;

    public void OnEnable()
    {
        _item.interactable = true;

        ChangeTransparency(20);
    }

    public void OnDisable()
    {
        _item.interactable = false;

        ChangeTransparency(255);
    }

    private void ChangeTransparency(float value)
    {
        var colors = _item.colors;
        colors.normalColor = new Color(255, 255, 255, value);
        _item.colors = colors;
    }

    public void Click()
    {
        Operation?.Invoke();
    }
}
