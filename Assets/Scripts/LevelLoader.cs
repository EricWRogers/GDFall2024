using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes

public class LevelLoader : MonoBehaviour
{
    // Reference to the player and their KeyPickup script
    public GameObject player;
    private KeyPickup playerKeyPickup;

    // Name of the scene to load
    public string BasementLevel;

    // The distance at which the player can interact with the door
    public float interactionDistance = 3f;

    void Start()
    {
        // Get the KeyPickup component from the player
        playerKeyPickup = player.GetComponent<KeyPickup>();
    }

    void Update()
    {
        // Check if the player is close enough to the door
        if (Vector3.Distance(player.transform.position, transform.position) < interactionDistance)
        {
            // Show message to interact (you can use UI for this)
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Check if the player has the key
                if (playerKeyPickup.hasKey)
                {
                    Debug.Log("Player has the key! Loading the scene...");
                    LoadLevel();
                }
                else
                {
                    Debug.Log("You need the key to open this door.");
                    // Optionally, show a UI message that the player needs the key
                }
            }
        }
    }

    // Method to load the scene
    private void LoadLevel()
    {
        if (!string.IsNullOrEmpty(BasementLevel))
        {
            Debug.Log("Loading scene: " + BasementLevel);
            SceneManager.LoadScene(BasementLevel);
        }
        else
        {
            Debug.LogWarning("Scene name is empty or invalid.");
        }
    }
}
