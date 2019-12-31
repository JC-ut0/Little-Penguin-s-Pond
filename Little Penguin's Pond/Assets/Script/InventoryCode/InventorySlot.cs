using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item; // current item in this slot
    public Image icon; // item's icon
    public Text text; // item's price

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        text.text = item.price.ToString();
        icon.enabled = true;
        text.enabled = true;
    }


    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        text.enabled = false;
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        InventoryManager.Instance.Remove(item);
    }

    // Use the item
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            RemoveItemFromInventory();
        }
        else
        {
            Debug.Log("Empty Slot!");
        }
    }

    public bool isEmpty()
    {
        return item == null;
    }
}