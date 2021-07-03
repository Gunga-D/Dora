using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private Weapon _holdingItem;
     
    private void Start()
    {
        _holdingItem = GetComponentInChildren<Weapon>(this.transform);
    }

    public bool IsHold()
    {
        if (_holdingItem)
            return true;

        return false;
    }

    public Weapon GetHoldingItem()
    {
        return _holdingItem;
    }

    public void Switch(Weapon newHoldingItem)
    {
        if (IsHold())
        {
            Destroy(_holdingItem.gameObject);
        }

        Weapon instance = Instantiate(newHoldingItem);

        _holdingItem = instance;

        instance.transform.SetParent(this.transform);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localScale = Vector3.one;
    }
}
