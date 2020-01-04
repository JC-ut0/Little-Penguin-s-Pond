using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public String name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int price;
    public GameObject _object;

    public bool Use()
    {
        Pond pond = Pond.Instance;
        if (pond.HasSpace())
        {
            pond.Add(_object);
            Debug.Log("Using item: " + name);
            return true;
        }
        return false;
    }
}