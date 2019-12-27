using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleTriggerEvent : MonoBehaviour
{
    public string scene;
    public bool enterTrigger;

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player" && !enterTrigger)
        {
            Debug.Log("Load Next Scene");
            SceneManager.LoadScene(scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && enterTrigger)
        {
            Debug.Log("Load Next Scene");
            SceneManager.LoadScene(scene);
        }
    }
}
