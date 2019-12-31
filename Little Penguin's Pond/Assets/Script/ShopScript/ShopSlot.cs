using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Text price;

    InventoryManager inventory;

    private void Start()
    {
        inventory = InventoryManager.Instance;
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
            if (item.Buy())
            {
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