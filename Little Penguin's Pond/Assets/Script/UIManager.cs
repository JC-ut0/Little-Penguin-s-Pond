using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AudioSource BGM;
    public GameObject shopUI;
    public GameObject inventoryUI;
    public GameObject musicOff;
    public GameObject musicOn;

    private void Start()
    {
        // if BGM exists
        if (GameObject.FindGameObjectWithTag("BGM") != null)
        {
            BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        }
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