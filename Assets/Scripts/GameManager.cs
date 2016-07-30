using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        //Instantiate(player, new Vector3(12, 12, 0), Quaternion.identity);       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
