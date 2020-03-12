using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        FISH, FOOD, SCENE
    }

    new public String name = "New Item";
    public Sprite icon = null;
    public ItemType type;
    public int price;
    public GameObject _object;

    public bool Use()
    {
        Pond pond = Pond.Instance;

        switch (type)
        {
            case ItemType.FISH:
                if (!pond.HasSpace())
                {
                    return false;
                }
                pond.Add(_object);
                break;

            case ItemType.FOOD:
                Instantiate(_object);
                break;

            case ItemType.SCENE:
                break;

            default:
                break;
        }

        Debug.Log("Using item: " + name);
        return true;
    }
}