using UnityEngine;
using System.Collections;
using System;

public class Chest : Interactable
{
    private Animator chest_animator;
    private bool isOpen;

    void Start()
    {
        chest_animator = this.gameObject.GetComponent<Animator>();
        isOpen = false;
        GetComponent<Interactable>().OnInteract = Open;
    }

    public void Open(GameObject interactor)
    {
        if (isOpen)
            return;

        if (interactor.tag == "Player")
        {
            chest_animator.SetBool("isOpen", true);
        }
    }
}
