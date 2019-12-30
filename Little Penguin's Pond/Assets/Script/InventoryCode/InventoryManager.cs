using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public List<Item> items;
    public int maxSpace = 20;
    public InventorySlot[] slots;

    public static InventoryManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public bool Add(Item item)
    {
        if (items.Count < maxSpace)
        {
            items.Add(item);
            AddItemToInventorySlot(item);
            return true;
        }
        return false;
    }

    private void AddItemToInventorySlot(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.AddItem(item);
                break;
            }
        }
    }

    public void Remove(Item item)
    {
        // use this item
        items.Remove(item);
    }
}