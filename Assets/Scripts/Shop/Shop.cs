using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shop : MonoBehaviour
{
    [SerializeField] private Bank _bank;
    private string _shopKey;
    private Inventory _inventory;
    private List<ShopItem> _boughtItems = new List<ShopItem>();

    protected void Initialize(string shopKey, List<ShopItem> allItems, Inventory inventory)
    {
        _shopKey = shopKey;
        _inventory = inventory;

        LoadItems(allItems);
    }

    private void LoadItems(List<ShopItem> allItems)
    {
        List<int> loadedItemIndexes = ExtensionMethods.GetListIntToMemory(_shopKey);

        if (loadedItemIndexes != null)
        {
            foreach (int index in loadedItemIndexes)
            {
                ShopItem soughtItem = allItems.First((ShopItem item) => item.Index == index);

                allItems.Remove(soughtItem);

                AddBoughtItem(soughtItem);
            }
        }

        if (allItems != null)
        {
            List<ShopItem> possibleToBuyItems = allItems;
            foreach (var item in possibleToBuyItems)
            {
                item.Handle(TryToBuy);
            }
        }
    }
    
    private void Receive(ShopItem item)
    {
        _inventory.Equip(item.Prefab);
    }

    private void TryToBuy(ShopItem item)
    {
        if (TryToPay(item))
        {
            item.UnHandle();

            AddBoughtItem(item);

            SaveBoughtItems();
        }
    }

    private bool TryToPay(ShopItem item)
    {
        if (_bank.GetBalance() >= item.Cost)
        {
            _bank.Withdraw(item.Cost);

            return true;
        }

        return false;
    }

    private void AddBoughtItem(ShopItem item)
    {
        _boughtItems.Add(item);

        item.ChangeStateToBought();

        item.Handle(Receive);
    }

    private void SaveBoughtItems()
    {
        ExtensionMethods.SaveListToMemory<int>(_shopKey, _boughtItems.Select((item) => item.Index).ToList());
    }
}
