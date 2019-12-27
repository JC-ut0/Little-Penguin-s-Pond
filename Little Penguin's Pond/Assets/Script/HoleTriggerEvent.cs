using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleTriggerEvent : MonoBehaviour
{
    public string scene;

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Load Next Scene");
            SceneManager.LoadScene(scene);
        }
    }
}
