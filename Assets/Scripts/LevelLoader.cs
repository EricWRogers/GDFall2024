using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTeleport : MonoBehaviour
{
    // The scene index of the next scene. Set this to the index of the next scene in your build settings.
    public int nextSceneIndex = 1;

    // Trigger detection when player enters the range
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Start the scene transition
            StartCoroutine(LoadNextScene());
        }
    }

    // Coroutine that handles loading the next scene
    private IEnumerator LoadNextScene()
    {
        // Optionally, you can add some transition effects here if you like (e.g., fade out)

        // Wait for a short time if you want to add delay before loading the next scene
        yield return new WaitForSeconds(1f);  // Delay can be adjusted or removed

        // Make sure the scene index is valid
        if (nextSceneIndex >= 0 && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Loading scene with index: " + nextSceneIndex);
            AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(nextSceneIndex);

            // Wait until the scene is fully loaded
            while (!sceneLoad.isDone)
            {
                yield return null;
            }

            Debug.Log("Scene loaded successfully.");
        }
        else
        {
            Debug.LogError("Invalid scene index: " + nextSceneIndex);
        }
    }
}
