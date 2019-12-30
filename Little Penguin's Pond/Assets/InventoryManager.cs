using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
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


    public void AddItem(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty())
            {
                slot.AddItem(item);
            }
        }
    }
}
