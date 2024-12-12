using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class TeleportToFirstScene : MonoBehaviour
{
    public float timeToTeleport = 10f;  // Time in seconds after which the player is teleported to index 0
    private float timer = 0f;  // Timer to track the elapsed time

    private void Update()
    {
        // Update the timer with the time passed since the last frame
        timer += Time.deltaTime;

        // If the timer exceeds the set timeToTeleport, teleport the player to index 0
        if (timer >= timeToTeleport)
        {
            TeleportToSceneZero();
        }
    }

    // Function to teleport the player to the first scene (scene with index 0)
    void TeleportToSceneZero()
    {
        // Load the scene with index 0 (the first scene in the build settings)
        SceneManager.LoadScene(0);
        Debug.Log("Teleported to the first scene (index 0)!");
    }
}
