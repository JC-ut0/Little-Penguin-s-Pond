using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public String name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int price;

    public void Use()
    {
        throw new NotImplementedException();
    }

    public bool Buy()
    {
        // if price <= player's money -> buy return true, add to inventory
        bool succeed =  InventoryManager.Instance.Add(this);
        if (succeed)
        {
            // reduce player's money
            return true;
        }
        return false;
    }
}