using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public Sprite Lady_Standing_1;    
    public Sprite walkRightSprite;  
    public Sprite walkLeftSprite;   
    public Sprite walkUpSprite;     
    public Sprite walkDownSprite;   

    private Rigidbody2D rb; 
    private SpriteRenderer spriteRenderer; 
    private Vector2 movement; 

    void Start()
    {
        // Get the Rigidbody2D and SpriteRenderer components attached to the player
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get player input (WASD or Arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Set the movement vector (left-right, up-down)
        movement = new Vector2(moveX, moveY).normalized; 

        //Change sprite based on the player's movement direction
        if (movement.x > 0) //Move right
        {
            spriteRenderer.sprite = walkRightSprite;
        }
        else if (movement.x < 0) //Move left
        {
            spriteRenderer.sprite = walkLeftSprite;
        }
        else if (movement.y > 0) //Move up
        {
            spriteRenderer.sprite = walkUpSprite;
        }
        else if (movement.y < 0) //Move down
        {
            spriteRenderer.sprite = walkDownSprite;
        }
        else //Idle (no movement)
        {
            spriteRenderer.sprite = Lady_Standing_1;
        }
    }

    void FixedUpdate()
    {
        //Apply the movement vector to the Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}