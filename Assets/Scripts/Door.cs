using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for UI components

public class Door : MonoBehaviour
{
    public KeyPickup playerKeyScript;  // Reference to the player's KeyPickup script
    public GameObject doorObject;  // The door object itself (it can be a door model, etc.)
    public bool isDoorOpen = false;  // Whether the door is open or closed
    public Text interactionText;  // Reference to the UI Text for interaction instructions
    public float interactionRange = 3f;  // The distance at which the player can interact with the door

    private BoxCollider2D doorCollider;  // To hold reference to the door's 2D collider

    private void Start()
    {
        // Get the BoxCollider2D attached to the door
        doorCollider = GetComponent<BoxCollider2D>();

        if (interactionText != null)
        {
            interactionText.text = "";  // Hide the text initially
        }
    }

    private void Update()
    {
        // Find the player object by tag and check the distance to the door
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && playerKeyScript != null)
        {
            // Calculate the distance between the player and the door
            float distanceToDoor = Vector3.Distance(player.transform.position, transform.position);

            // Check if the player is within range and has the key
            if (distanceToDoor <= interactionRange && playerKeyScript.hasKey)
            {
                // Show interaction prompt if within range and the player has the key
                if (interactionText != null)
                {
                    interactionText.text = "Press E to open the door";  // Display prompt
                }

                // If the player presses 'E' and the door is not open, open it
                if (Input.GetKeyDown(KeyCode.E) && !isDoorOpen)
                {
                    OpenDoor();
                }
            }
            else
            {
                // Hide the prompt if the player is out of range or doesn't have the key
                if (interactionText != null)
                {
                    interactionText.text = "";
                }
            }
        }
    }

    // Open the door when the player interacts with it
    void OpenDoor()
    {
        isDoorOpen = true;
        doorObject.SetActive(false);  // Deactivates the door object to simulate it being "opened"
        Debug.Log("The door is now open.");
        
        // Remove the BoxCollider2D so the player can pass through the door
        if (doorCollider != null)
        {
            doorCollider.enabled = false;  // Disable the collider (removes physical interaction)
            Debug.Log("The door's collider has been removed.");
        }

        // Hide the prompt after the door is opened
        if (interactionText != null)
        {
            interactionText.text = "";
        }
    }
}