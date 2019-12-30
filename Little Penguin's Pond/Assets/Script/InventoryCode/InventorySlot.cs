using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Text text;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        text.text = item.price.ToString();
        icon.enabled = true;
        text.enabled = true;
    }

    public void UseItem()
    {
        if (item != null)
        {
            // put this item to the pond
            Debug.Log(item.name + " is in the pond now!");
            icon.enabled = false;
            text.enabled = false;
            InventoryManager.Instance.Remove(item);
            item.Use();
        }
        Debug.Log("no item in this slot!");
    }

    public bool isEmpty()
    {
        return item == null;
    }
}