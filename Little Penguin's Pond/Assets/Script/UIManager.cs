﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AudioSource BGM;
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
        BGM.mute = true;
        musicOff.SetActive(true);
        musicOn.SetActive(false);
    }
    public void OnMusic()
    {
        BGM.mute = false;
        musicOff.SetActive(false);
        musicOn.SetActive(true);
    }
}
