using UnityEngine;
using System.Collections;

public class PickUp : Interactable
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InteractableList interactableList = other.GetComponent<InteractableList>();
            interactableList.RegisterInteractable(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InteractableList interactableList = other.GetComponent<InteractableList>();
            interactableList.UnregisterInteractable(this);
        }
    }
}
