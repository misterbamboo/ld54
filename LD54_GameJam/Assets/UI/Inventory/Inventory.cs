using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items = new List<Item>();

    private static Inventory _instance;

    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Inventory>();
            }
            return _instance;
        }
    }

    public void Start()
    {
        foreach (var item in items)
        {
              item.rowItem.Init(item.name);
        }
    }

    public void AddItem(string name)
    {
        Item item = items.Find(i => i.name.ToLower() == name);
        item.qty = item.qty + 1;
        item.rowItem.UpdateQty(item.qty);       
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public int qty;
    public RowItem rowItem;
}
