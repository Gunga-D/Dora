using UnityEngine;

public class SeaWave : MonoBehaviour
{
    [SerializeField] private AnimationClip _action;
    private float _speed;

    private void Start()
    {
        Destroy(this.gameObject, _action.length);
    }

    public void Initialize(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
    }
}
