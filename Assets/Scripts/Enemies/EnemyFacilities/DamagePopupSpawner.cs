using UnityEngine;

public class DamagePopupSpawner : MonoBehaviour
{
    [SerializeField] private DamagePopup _damagePopupPrefab;
    [SerializeField] private float _lifeTime;

    public void Spawn(Vector3 position, float damageAmount)
    {
        DamagePopup instance = Instantiate(_damagePopupPrefab, position, Quaternion.identity);
        instance.Setup(Mathf.Ceil(damageAmount).ToString());
        instance.transform.SetParent(transform.parent);

        Destroy(instance.gameObject, _lifeTime);
    }
}
