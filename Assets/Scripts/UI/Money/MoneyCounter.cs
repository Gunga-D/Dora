using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    private Text _score;
    private Image _icon;

    private void Start()
    {
        _score = GetComponentInChildren<Text>();
        _icon = GetComponentInChildren<Image>();
    }

    public void UpdateValue(int value)
    {
        _score.text = value.ToString();
    }
}
