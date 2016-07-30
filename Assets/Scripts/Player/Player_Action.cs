using UnityEngine;
using System.Collections;

public class Player_Action : MonoBehaviour
{
    public float rayDistance;
    public LayerMask interactLayer;

    private Animator player_animator;
    private Vector2 direction;
    void Start()
    {
        player_animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        bool interact_pressed = Input.GetAxisRaw("Interact") > 0 ? true : false;
        if (interact_pressed)
        {
            direction = new Vector2(player_animator.GetFloat("moveX"), player_animator.GetFloat("moveY"));
            TriggerAction(direction);
        }
    }

    void TriggerAction(Vector2 direction)
    {

    }
}
