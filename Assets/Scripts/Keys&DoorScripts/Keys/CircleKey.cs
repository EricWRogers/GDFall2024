using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CircleKey : MonoBehaviour
{
    public bool hasCircleKey = false;  // Tracks whether the player has picked up the Circle Key
    public TMP_Text pickupMessageText;  // Reference to the UI Text for feedback
    public TMP_Text interactionText;    // Reference to the UI Text for interaction feedback
    public float pickupRange = 3f;  // The distance at which the player can pick up the key

    // New addition: Reference to the Image that will appear after the key is picked up
    public Image circleKeyImage;  

    private GameObject player;  // Reference to the player GameObject

    void Awake()
    {
        // Ensure this GameObject persists across scenes
        //DontDestroyOnLoad(gameObject);

        // If the key has already been picked up in the previous scene, we want to keep the state
        if (hasCircleKey && circleKeyImage != null)
        {
            circleKeyImage.enabled = true; // Make sure the UI element reflects the state
        }
    }

    private void Start()
    {
        // Initially, the player does not have the key
        if (pickupMessageText != null)
        {
            pickupMessageText.text = "";  // Hide any pickup message at the start
        }

        // Make sure the key image is hidden at the start
        if (circleKeyImage != null)
        {
            circleKeyImage.enabled = false;  // Hide the circle key image initially
        }

        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Check if player is close enough to the key and if the player has not already picked it up
        if (player != null && !hasCircleKey)
        {
            float distanceToKey = Vector3.Distance(player.transform.position, transform.position);

            // Check if the player is within range to pick up the key
            if (distanceToKey <= pickupRange)
            {
                // Show a message to prompt the player to press 'E' to pick up the key
                if (pickupMessageText != null)
                {
                    pickupMessageText.text = "Press E to pick up";
                }

                // Wait for the player to press 'E'
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickUpCircleKey();
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

    // Pick up the Circle Key when the player presses 'E'
    void PickUpCircleKey()
    {
        // Set the hasCircleKey flag to true
        hasCircleKey = true;

        // Update the message to show key picked up
        if (pickupMessageText != null)
        {
            pickupMessageText.text = "Circle Key picked up!";
        }

        // Show the key image in the UI
        if (circleKeyImage != null)
        {
            circleKeyImage.enabled = true;  // Make the circle key image visible
        }

        // Hide the prompt after the key is picked up
        if (pickupMessageText != null)
        {
            pickupMessageText.text = "";
        }

        // Deactivate the key object so it no longer interferes with the player
        gameObject.SetActive(false);  // Deactivate the key object (but don't destroy it)

        // Log for debugging purposes
        Debug.Log("Circle Key picked up!");
    }
}
