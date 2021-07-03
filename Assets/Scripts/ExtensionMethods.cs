using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ExtensionMethods
{
    public static T TryToFindComponent<T>(Component where)
    {
        T component = where.GetComponent<T>();

        if (component.Equals(null))
        {
            component = where.GetComponentInChildren<T>();
        }

        if (component.Equals(null))
        {
            component = where.GetComponentInParent<T>();
        }

        return component;
    }

    public static void SaveListToMemory<T>(string key, List<T> list)
    {
        string combinded = string.Join(",", list);

        PlayerPrefs.SetString(key, combinded);
    }

    public static List<int> GetListIntToMemory(string key)
    {
        string received = PlayerPrefs.GetString(key);

        if (received == "")
        {
            return null;
        }

        return received.Split(',').Select(x => int.Parse(x)).ToList();
    }
}
