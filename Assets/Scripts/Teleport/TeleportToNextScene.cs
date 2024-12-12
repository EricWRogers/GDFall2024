using UnityEngine;
using UnityEngine.SceneManagement;  // To load scenes

public class TeleportToNextScene : MonoBehaviour
{
    public GameObject targetObject;  // The target GameObject to check the distance to
    public float interactionRange = 3f;  // The distance at which the player can teleport
    public KeyCode teleportKey = KeyCode.E;  // The key the player needs to press to teleport (set to E)

    private void Update()
    {
        // Find the player object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && targetObject != null)
        {
            // Calculate the distance between the player and the target object
            float distanceToTarget = Vector3.Distance(player.transform.position, targetObject.transform.position);

            // If the player is within range of the target object
            if (distanceToTarget <= interactionRange)
            {
                // Check if the player presses the teleport key (E)
                if (Input.GetKeyDown(teleportKey))
                {
                    TeleportPlayerToNextScene();
                }
            }
        }
    }

    // Teleport the player to the next scene
    void TeleportPlayerToNextScene()
    {
        // Get the current scene index and load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;  // Assuming the next scene is the one following it

        // Check if the next scene index is valid (avoids errors if you're at the last scene in the build)
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Teleported to next scene!");
        }
        else
        {
            Debug.LogWarning("No next scene available!");
        }
    }
}
