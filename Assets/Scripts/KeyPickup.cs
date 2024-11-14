using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for UI components

public class KeyPickup : MonoBehaviour
{
    public bool hasKey = false;  // Tracks whether the player has picked up the key
    public Text pickupMessageText;  // Reference to the UI Text for feedback
    public Text interactionText;    // Reference to the UI Text for interaction feedback
    public float pickupRange = 3f;  // The distance at which the player can pick up the key

    private GameObject player;  // Reference to the player GameObject

    private void Start()
    {
        // Initially, the player does not have the key
        if (pickupMessageText != null)
        {
            pickupMessageText.text = "";  // Hide any pickup message at the start
        }

        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Check if player is close enough to the key and if the player has not already picked it up
        if (player != null && !hasKey)
        {
            float distanceToKey = Vector3.Distance(player.transform.position, transform.position);

            // Check if the player is within range to pick up the key
            if (distanceToKey <= pickupRange)
            {
                // Show a message to prompt the player to press 'E' to pick up the key
                if (pickupMessageText != null)
                {
                    pickupMessageText.text = "Press E to pick up the key";
                }

                // Wait for the player to press 'E'
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickUpKey();
                }
            }
            else
            {
                // Hide the message if the player is out of range
                if (pickupMessageText != null)
                {
                    pickupMessageText.text = "";
                }
            }
        }
    }

    // Pick up the key when the player presses 'E'
    void PickUpKey()
    {
        // Set the hasKey flag to true
        hasKey = true;

        // Update the message to show key picked up
        if (pickupMessageText != null)
        {
            pickupMessageText.text = "Key picked up!";
        }

        // Deactivate the key object so it no longer interferes with the player
        gameObject.SetActive(false);  // Deactivate the key object (but don't destroy it)

        // Log for debugging purposes
        Debug.Log("Key picked up!");
    }
}