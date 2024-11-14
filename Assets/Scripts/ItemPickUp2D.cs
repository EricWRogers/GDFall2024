using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // For handling UI elements

public class ItemPickup2D : MonoBehaviour
{
    // public string itemType = "Health";  // Type of item (can be "Health", "Score", etc.)
    public Image pickupImage;          // UI Image to display when item is picked up
    public Sprite itemIcon;            // Icon to show when picked up

    private void Start()
    {
        // Initially, hide the image in the UI
        if (pickupImage != null)
        {
            pickupImage.enabled = false;
        }
    }

    // This is called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the item (player tagged as "Player")
        if (other.CompareTag("Player"))
        {
            // Call the method to handle the item pickup
            PickupItem();

            // Destroy the item after pickup (this removes it from the scene)
            Destroy(gameObject);
        }
    }

    // Method to handle the item pickup logic
    private void PickupItem()
    {
        // If an image exists, update it and display it
        if (pickupImage != null && itemIcon != null)
        {
            // Set the image's sprite to the item's icon
            pickupImage.sprite = itemIcon;

            // Enable the image so it shows up in the UI
            pickupImage.enabled = true;
        }

        // Optionally, you can implement other pickup logic (e.g., increasing score, health, etc.)
        // Debug.Log(itemType + " picked up!");
    }
}
