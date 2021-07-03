using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopItemButtonHandler : MonoBehaviour
{
    [SerializeField] private Color _boughtMainIconColor;
    [SerializeField] private string _boughtButtonText;
    [SerializeField] private Color _boughtButtonColor;

    [SerializeField] private Image _mainIcon;
    [SerializeField] private Text _costText;
    [SerializeField] private GameObject _infoElement;
    [SerializeField] private Text _buttonText;
    [SerializeField] private Button _button;

    public Action Putted;

    public void Initialize(int cost)
    {
        _costText.text = cost.ToString();
    }

    public void Click()
    {
        Putted?.Invoke();
    }

    public void ChangeToBoughtStyle()
    {
        _mainIcon.color = _boughtMainIconColor;

        _buttonText.text = _boughtButtonText;

        var colors = _button.colors;
        colors.normalColor = _boughtButtonColor;
        _button.colors = colors;

        _infoElement.SetActive(false);
    }
}
