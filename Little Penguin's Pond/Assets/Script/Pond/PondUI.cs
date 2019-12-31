using UnityEngine;

public class PondUI : MonoBehaviour
{
    private Pond pond;    // Pond Script
    GameObject[] gameObjects;
    private void Start()
    {
        pond = Pond.Instance;
        pond.onObjectChangedCallback += UpdateGUI;


        gameObjects = GameObject.FindGameObjectsWithTag("Fish");

    }

    // Check to see if we should open/close the inventory
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
        }
            UpdateGUI();
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateGUI()
    {
        // SpriteRenderer[] slots = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < gameObjects.Length; i++)
        {
            // Debug.Log(gameObjects[i] + " i:" +i + " pond.objects.Count:"  + pond.objects.Count);

            if (i < pond.objects.Count)
            {
                gameObjects[i].SetActive(true);
                gameObjects[i].GetComponent<SpriteRenderer>().sprite = pond.objects[i].GetComponent<SpriteRenderer>().sprite;
                gameObjects[i].GetComponent<Animator>().runtimeAnimatorController = pond.objects[i].GetComponent<Animator>().runtimeAnimatorController;
                // Debug.Log(gameObjects[i] + "true");
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
        /*
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < pond.objects.Count)
            {
                GameObject slot =  slots[i].gameObject;
                Debug.Log(slot.activeSelf);
                slots[i].gameObject.SetActive(true);
                Debug.Log(slot);
                Debug.Log(slot.activeSelf);
                slots[i].sprite = pond.objects[i].GetComponent<SpriteRenderer>().sprite;
                slot.GetComponent<Animator>().runtimeAnimatorController = pond.objects[i].GetComponent<Animator>().runtimeAnimatorController;
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
        */
    }

    private void OnDestroy()
    {
        pond.onObjectChangedCallback -= UpdateGUI;
    }
}