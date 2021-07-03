using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private float _shakeDuration;
    private float _shakeAmount;
    private float _decreaseFactor;

    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (_shakeDuration > 0)
        {
            transform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeAmount;

            _shakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            _shakeDuration = 0f;
            transform.localPosition = _originalPosition;
        }
    }

    public void StartEffect(float shakeDuration, float shakeAmount, float decreaseFactor)
    {
        _shakeDuration = shakeDuration;
        _shakeAmount = shakeAmount;
        _decreaseFactor = decreaseFactor;
    }
}
