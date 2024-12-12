using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management
using UnityEngine.UI;  // For UI Button interactions

public class ResetSceneOnCreditsClick : MonoBehaviour
{
    public float timeToReset = 10f;  // Time in seconds after which the scene will reset
    private float timer = 0f;  // Timer to track the elapsed time
    private bool resetTriggered = false;  // To check if the reset timer has been triggered

    public Button creditsButton;  // Reference to the UI Credits button

    private void Start()
    {
        // Ensure the button is assigned in the Inspector
        if (creditsButton != null)
        {
            creditsButton.onClick.AddListener(StartResetTimer);  // Add listener to button click
        }
    }

    private void Update()
    {
        // If the reset has been triggered, start counting down
        if (resetTriggered)
        {
            timer += Time.deltaTime;

            // If the timer exceeds the set timeToReset, reset the scene
            if (timer >= timeToReset)
            {
                ResetScene();
            }
        }
    }

    // This method is called when the Credits button is clicked
    void StartResetTimer()
    {
        // Start the timer when the Credits button is clicked
        resetTriggered = true;
        Debug.Log("Credits button clicked. Scene will reset after " + timeToReset + " seconds.");
    }

    // Function to reset the scene
    void ResetScene()
    {
        // Get the current scene's index and reload it
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("Scene has been reset after credits.");
    }
}
