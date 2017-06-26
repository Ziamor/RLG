using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float speed;
    public LayerMask interact_layer;

    private Rigidbody2D player_rigidbody2D;
    private Animator player_animator;
    //private Collider2D player_collider;
    //private InteractableList interactableList;
    private BaseInventory playerInventory;

    private Vector2 dir;

    void Start()
    {
        player_rigidbody2D = this.GetComponent<Rigidbody2D>();
        player_animator = this.GetComponent<Animator>();
        //player_collider = this.GetComponent<Collider2D>();
        //interactableList = this.GetComponent<InteractableList>();
        playerInventory = this.GetComponent<BaseInventory>();

        player_rigidbody2D.freezeRotation = true;
        
        playerInventory.AddItemToInventory("Old Sword");
        playerInventory.AddItemToInventory("Steel Sword");
        playerInventory.AddItemToInventory("Infernal Sword");
        playerInventory.AddItemToInventory("Hematite");
        playerInventory.AddItemToInventory("Copper Ore");
    }

    void Update()
    {
        Vector2 mov_vec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Check if is walking
        if (mov_vec != Vector2.zero)
        {
            player_animator.SetBool("is_walking", true);
            player_animator.SetFloat("moveX", mov_vec.x);
            player_animator.SetFloat("moveY", mov_vec.y);
        }
        else
            player_animator.SetBool("is_walking", false);

        // Move the player
        player_rigidbody2D.MovePosition(player_rigidbody2D.position + mov_vec * speed * Time.deltaTime);

        if (Input.GetKeyDown("e"))
        {
            dir = new Vector2(player_animator.GetFloat("moveX"), player_animator.GetFloat("moveY"));
            RaycastHit2D ray = Physics2D.Raycast(transform.position, dir, 0.25f, interact_layer);
            if (ray)
            {
                Interactable inter = ray.collider.GetComponent<Interactable>();
                if (inter != null)
                {
                    inter.OnInteract.Invoke(this.gameObject);
                }
            }
        }
    }
}
