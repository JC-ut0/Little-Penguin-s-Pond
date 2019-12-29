using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject BGM;
    public GameObject shopUI;
    public GameObject inventoryUI;
    public GameObject musicOff;
    public GameObject musicOn;


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
    public void OnMute()
    {
        BGM.SetActive(false);
        musicOff.SetActive(true);
        musicOn.SetActive(false);
    }
    public void OnMusic()
    {
        BGM.SetActive(true);
        musicOff.SetActive(false);
        musicOn.SetActive(true);
    }
}
