using UnityEngine;
using System.Collections;

public class HealthPotionPickup : PickUp
{
    public float healAnount = 25;
	// Use this for initialization
	void Start () {
        GetComponent<Interactable>().OnInteract = gather;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gather(GameObject interactor)
    {
        if (interactor.tag == "Player")
        {
            HealthComponent hp = interactor.gameObject.GetComponent<HealthComponent>();
            hp.Heal(healAnount);
            Destroy(this.gameObject);
        }
    }
}
