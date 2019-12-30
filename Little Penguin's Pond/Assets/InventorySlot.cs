using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image icon;


    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    public void useItem()
    {
        if (item != null)
        {
            // put this item to the pond
            Debug.Log(item.name + " is in the pond now!");
            item.Use();
        }
        Debug.Log("no item in this slot!");
    }

    public bool isEmpty()
    {
        return item == null;
    }

}
