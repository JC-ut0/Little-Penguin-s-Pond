using UnityEngine;

public class PondUI : MonoBehaviour
{
    private Pond pond;    // Pond Script
    private GameObject[] fishSlots;

    private void Start()
    {
        pond = Pond.Instance;
        pond.onObjectChangedCallback += UpdateGUI;

        fishSlots = GameObject.FindGameObjectsWithTag("Fish");
    }

    // Check to see if we should open/close the inventory
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
        }
        UpdateGUI();
    }

    // Update the Pond UI by:
    //		- Adding Fish
    //		- Sell Fish
    // This is called using a delegate on the Pond.
    public void UpdateGUI()
    {
        // SpriteRenderer[] slots = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < fishSlots.Length; i++)
        {
            // Debug.Log(gameObjects[i] + " i:" +i + " pond.objects.Count:"  + pond.objects.Count);

            if (i < pond.fishObjects.Count)
            {
                fishSlots[i].SetActive(true);
                fishSlots[i].GetComponent<SpriteRenderer>().sprite = pond.fishObjects[i].GetComponent<SpriteRenderer>().sprite;
                fishSlots[i].GetComponent<Animator>().runtimeAnimatorController = pond.fishObjects[i].GetComponent<Animator>().runtimeAnimatorController;
                if (pond.fishObjects[i].name == "八爪鱼")
                {
                    fishSlots[i].GetComponent<FishManager>().turnAble = false;
                }
                else
                {
                    fishSlots[i].GetComponent<FishManager>().turnAble = true;
                }
            }
            else
            {
                fishSlots[i].SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        pond.onObjectChangedCallback -= UpdateGUI;
    }
}