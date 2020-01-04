using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    #region Singleton

    private static Pond _instance;
    public static Pond Instance { get { return _instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public delegate void OnObjectChanged();
    public OnObjectChanged onObjectChangedCallback;

    public List<GameObject> fishObjects = new List<GameObject>();

    public int maxSpace = 20;

    public bool Add(GameObject @object)
    {
        if (fishObjects.Count < maxSpace)
        {
            fishObjects.Add(@object);
            if (onObjectChangedCallback != null)
                onObjectChangedCallback.Invoke();
            return true;
        }
        return false;
    }
    public bool HasSpace()
    {
        return fishObjects.Count < maxSpace;
    }


    public void Remove(GameObject @object)
    {
        fishObjects.Remove(@object);
        if (onObjectChangedCallback != null)
            onObjectChangedCallback.Invoke();
    }

    private void Update()
    {
    }
}
