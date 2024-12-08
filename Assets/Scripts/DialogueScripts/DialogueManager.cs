using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Make sure TextMesh Pro is included for the TMP_Text component

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;  // UI Text component to display the dialogue.
    public GameObject dialoguePanel;  // Panel that holds the dialogue UI.
    public float typingSpeed = 0.05f;  // Speed of typing each letter.

    private Queue<string> sentences;  // To hold sentences and display one by one.

    // Start is called before the first frame update
    private void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);  // Make sure the dialogue panel is hidden at the start
    }

    // Method to start the dialogue with a list of sentences
    public void StartDialogue(List<string> dialogueSentences)
    {
        sentences.Clear();  // Clear any previous dialogue
        dialoguePanel.SetActive(true);  // Show the dialogue panel

        // Enqueue each sentence from the list into the queue
        foreach (string sentence in dialogueSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();  // Show the first sentence immediately
    }

    // Method to display the next sentence
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();  // End the dialogue if no more sentences
            return;
        }

        string sentence = sentences.Dequeue();  // Get the next sentence from the queue
        StopAllCoroutines();  // Stop any ongoing typing animation
        StartCoroutine(TypeSentence(sentence));  // Start typing the next sentence
    }

    // Coroutine to type each letter of the sentence one by one
    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";  // Clear the text initially

        foreach (char letter in sentence)
        {
            dialogueText.text += letter;  // Add one letter at a time to the text
            yield return new WaitForSeconds(typingSpeed);  // Wait for the typing speed
        }
    }

    // Method to end the dialogue and hide the panel
    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);  // Hide the dialogue panel
        Debug.Log("End of dialogue.");
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for Space key press to display the next sentence
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();  // Display the next sentence when space is pressed
        }
    }
}
