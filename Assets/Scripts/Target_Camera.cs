using UnityEngine;
using System.Collections;

public class Target_Camera : MonoBehaviour
{

    public Transform target;
    public float scale;

    private Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.orthographicSize = (Screen.height / 100f / scale);
        this.transform.position = target.position + new Vector3(0, 0, -10f);
    }
}
