using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Text price;

    PlayerEntity player;

    InventoryManager inventory;

    private void Start()
    {
        inventory = InventoryManager.Instance;
        player = PlayerEntity.Instance;
        if (item != null)
        {
            icon.sprite = item.icon;
            price.text = item.price.ToString();
            icon.enabled = true;
            price.enabled = true;
        }
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
    }

    public void Buy()
    {
        if (item != null)
        {
            if (inventory.HasSpace() && item.price <= player.gemNum)
            {
                inventory.Add(item);
                player.gemNum -= item.price;
                Debug.Log(item.name + " is your Inventory now!");
            }
            else
            {
                Debug.Log("Failed to buy " + item.name);
            }
        }
        else { Debug.Log("no item in this slot!"); }
    }

    public bool isEmpty()
    {
        return item == null;
    }
}