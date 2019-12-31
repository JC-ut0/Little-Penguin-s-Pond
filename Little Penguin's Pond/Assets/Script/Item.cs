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
        Debug.Log("Using item: " + name);
    }
}