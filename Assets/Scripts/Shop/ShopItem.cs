using UnityEngine;
using System;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private int _cost;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ShopItemButtonHandler _handler;

    public int Index
    {
        get
        {
            return _index;
        }
    }

    public int Cost
    {
        get
        {
            return _cost;
        }
    }

    public GameObject Prefab
    {
        get
        {
            return _prefab;
        }
    }

    private void Awake()
    {
        _handler.Initialize(_cost);
    }

    public void ChangeStateToBought()
    {
        _handler.ChangeToBoughtStyle();
    }

    public void UnHandle()
    {
        _handler.Putted = null;
    }

    public void Handle(Action<ShopItem> act)
    {
        _handler.Putted += ()=>act?.Invoke(this);
    }
}
