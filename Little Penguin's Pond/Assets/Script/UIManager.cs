using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject inventoryUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnShopOpen()
    {
        shopUI.SetActive(true);
    }
    public void OnShopClosed()
    {
        shopUI.SetActive(false);
    }
    public void OnInventoryOpen()
    {
        inventoryUI.SetActive(true);
    }
    public void OnInventoryClosed()
    {
        inventoryUI.SetActive(false);
    }
}
