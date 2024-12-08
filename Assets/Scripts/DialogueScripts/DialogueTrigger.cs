using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float interactionRange = 3f;  // Range in which the player can interact
    private bool playerInRange = false;  // To check if the player is in range

    public DialogueManager dialogueManager;  // Reference to the DialogueManager

    // Define the dialogue sentences here
    private List<string> dialogueSentences = new List<string>
    {
        "Hello, welcome to this world!",
        "This is a simple dialogue system.",
        "Press Space to continue the conversation."
    };

    // Update is called once per frame
    private void Update()
    {
        // Only trigger the dialogue if the player is within range
        if (playerInRange && Input.GetKeyDown(KeyCode.E))  // E is for starting dialogue
        {
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(dialogueSentences);  // Start the dialogue when E is pressed
            }
        }
    }

    // Trigger enters the range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;  // Player is within range
        }
    }

    // Trigger exits the range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;  // Player is no longer in range
        }
    }
}
