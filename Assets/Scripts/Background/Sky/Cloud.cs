using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _speed;

    public void Initialize(float speed)
    {
        _speed = speed;
    }

    public void SetDestruction(float lifeTime)
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
}
