using UnityEngine;

public class WeaponInventory : Inventory
{
    [SerializeField] private WeaponHolder _holder;

    public override void Equip(GameObject item)
    {
        _holder.Switch(ExtensionMethods.TryToFindComponent<Weapon>(item.transform));
    }
}
