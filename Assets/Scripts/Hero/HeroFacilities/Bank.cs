using UnityEngine;

public class Bank : MonoBehaviour
{
    private int _money;
    public static Bank Instance;

    private void Awake()
    {
        _money = GetFromMemory();

        Instance = this;
    }

    private int GetFromMemory()
    {
        return PlayerPrefs.GetInt("Money");
    }

    private void SaveToMemory(int value)
    {
        PlayerPrefs.SetInt("Money", value);
    }

    public void Deposit(int money)
    {
        _money += money;

        SaveToMemory(_money);
    }

    public void Withdraw(int money)
    {
        _money -= money;

        SaveToMemory(_money);
    }

    public int GetBalance()
    {
        return _money;
    }
}
