using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AudioSource BGM;
    public GameObject shop;
    public GameObject inventory;
    public GameObject musicOff;
    public GameObject musicOn;

    public Text gemNum;
    PlayerEntity player;

    private void Start()
    {
        // if BGM exists
        if (GameObject.FindGameObjectWithTag("BGM") != null)
        {
            BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        }
        player = PlayerEntity.Instance;
    }

    private void Update()
    {
        gemNum.text = player.gemNum.ToString();  
    }
    public void OnShopOpen()
    {
        CloseAll();
        shop.SetActive(true);
    }

    public void OnShopClosed()
    {
        shop.SetActive(false);
    }

    public void OnInventoryOpen()
    {
        CloseAll();
        inventory.SetActive(true);
    }

    public void OnInventoryClosed()
    {
        inventory.SetActive(false);
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

    private void CloseAll()
    {
        inventory.SetActive(false);
        shop.SetActive(false);
    }
}