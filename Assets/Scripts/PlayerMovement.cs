using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    public float moveSpeed = 5f; // Movement speed of the player


    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    private Vector2 movement; // Holds player movement input


    void Start()

    {

        // Get the Rigidbody2D component attached to the player

        rb = GetComponent<Rigidbody2D>();

    }


    void Update()

    {

        // Get player input (WASD or Arrow keys)

        float moveX = Input.GetAxisRaw("Horizontal");

        float moveY = Input.GetAxisRaw("Vertical");


        // Set the movement vector (left-right, up-down)

        movement = new Vector2(moveX, moveY).normalized; // Normalize to avoid diagonal speed boost

    }


    void FixedUpdate()

    {

        // Apply the movement vector to the Rigidbody2D

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

}