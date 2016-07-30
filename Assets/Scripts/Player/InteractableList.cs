using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableList : MonoBehaviour
{

    private List<Interactable> interactableObjects;

    // Use this for initialization
    void Start()
    {
        interactableObjects = new List<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        interactableObjects.RemoveAll(item => item == null);
    }

    public bool RegisterInteractable(Interactable inter)
    {
        Debug.Log("Registering " + inter.ToString());
        if (!interactableObjects.Contains(inter))
        {
            interactableObjects.Add(inter);
            return true;
        }
        return false;
    }

    public bool UnregisterInteractable(Interactable inter)
    {
        Debug.Log("Unregistering " + inter.ToString());
        if (interactableObjects.Contains(inter))
        {
            interactableObjects.Remove(inter);
            return true;
        }
        return false;
    }

    public bool IsInteractableInRange()
    {
        if (interactableObjects.Count > 0)
            return true;
        return false;
    }
}
