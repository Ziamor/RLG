using UnityEngine;
using System.Collections;

public class TestTrigger : MonoBehaviour
{
    public bool isHeal = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Entered");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exit");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthComponent hp = other.gameObject.GetComponent<HealthComponent>();
            if (isHeal)
                hp.Heal(0.5f);
            else
                hp.Damage(0.5f);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
