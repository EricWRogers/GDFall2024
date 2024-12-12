using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import the UI namespace to work with UI elements like Image

public class DialogueTrigger : MonoBehaviour
{
    public float interactionRange = 3f;  // Range in which the player can interact
    private bool playerInRange = false;  // To check if the player is in range

    public DialogueManager dialogueManager;  // Reference to the DialogueManager

    // Define the dialogue sentences here
    private List<string> dialogueSentences = new List<string>
    {
        "Listen we don't have much time!",
        "She'll be here any second.",
        "The lady of this house has hidden keys around the room.",
        "There are 3 different keys you need to find!",
        "I need you to let me out so we can escape",
    };

    // Interaction indicator components
    public Canvas interactionCanvas;  // Canvas to hold the interaction image
    public Image interactIndicator;    // Reference to the Image component that will act as the indicator

    private void Start()
    {
        // Ensure the interaction image is hidden at the start
        if (interactionCanvas != null)
        {
            interactionCanvas.gameObject.SetActive(false);  // Hide canvas initially
        }
    }

    private void Update()
    {
        // Only trigger the dialogue if the player is within range
        if (playerInRange)
        {
            // Show the interaction indicator when player is in range
            if (interactionCanvas != null)
            {
                interactionCanvas.gameObject.SetActive(true);  // Show canvas
            }

            // Trigger the dialogue if "E" is pressed
            if (Input.GetKeyDown(KeyCode.E))  // E is for starting dialogue
            {
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(dialogueSentences);  // Start the dialogue when E is pressed
                }
            }
        }
        else
        {
            // Hide the interaction indicator when player is out of range
            if (interactionCanvas != null)
            {
                interactionCanvas.gameObject.SetActive(false);  // Hide canvas
            }
        }
    }

    // Trigger enters the range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;  // Player is within range
            Debug.Log("Player entered interaction range.");

            // Ensure the indicator is shown when entering the range
            if (interactionCanvas != null)
            {
                interactionCanvas.gameObject.SetActive(true);  // Show canvas when the player enters range
            }
        }
    }

    // Trigger exits the range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;  // Player is no longer in range
            Debug.Log("Player exited interaction range.");

            // Ensure the indicator is hidden when exiting the range
            if (interactionCanvas != null)
            {
                interactionCanvas.gameObject.SetActive(false);  // Hide canvas when the player exits range
            }
        }
    }
}
