using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : Interactable
{
    public StrawBerryPlant plantPrefab;

    private StrawBerryPlant plant;
    private bool growing;

    void Start()
    {
        this.growing = false;
        GetComponent<Interactable>().OnInteract = Farm;
    }

    public void Farm(GameObject interactor)
    {
        if (interactor != null && interactor.tag == "Player")
        {
            if (!growing && plantPrefab != null)
            {
                growing = true;
                plant = Instantiate(plantPrefab, this.transform.position, Quaternion.identity);
                plant.transform.parent = this.transform;
            }
            else if (plant != null && plant.IsReadyForHarvest())
            {
                if (plant.Harvest(interactor.GetComponent<Player>()))
                {
                    Destroy(plant.gameObject);
                    plant = null;
                    growing = false;
                }
            }
        }
    }
}
