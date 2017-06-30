using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : Interactable
{
     private bool active = false;

    void Start()
    {
        GetComponent<Interactable>().OnInteract = OpenSmeltWindow;
    }

    public void OpenSmeltWindow(GameObject interactor)
    {
        if (interactor.tag == "Player")
        {
            Debug.Log("Smelter Interact");
            active = !active;
            InventoryUI.Instance.ShowSmelter(active);
            StartCoroutine(InProximity(interactor));
        }
    }

    IEnumerator InProximity(GameObject target)
    {
        float maxDist = 0.64f;
        while (active)
        {
            Debug.Log(Vector3.Distance(transform.position, target.transform.position));
            if (Vector3.Distance(transform.position, target.transform.position) > maxDist)
            {
                active = false;
                InventoryUI.Instance.ShowSmelter(active);
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
