using UnityEngine.UI;

public class FireRateBarHero : Bar
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public override void UpdateValue(float percent)
    {
        _slider.value = _slider.maxValue * percent;
    }
}
