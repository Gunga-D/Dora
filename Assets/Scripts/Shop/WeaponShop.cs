using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : Shop
{
    [SerializeField] private Inventory _pack;
    [SerializeField] private List<ShopItem> _allWeapons = new List<ShopItem>();

    private void Awake()
    {
        Initialize("WeaponShop", _allWeapons, _pack);
    }
}
