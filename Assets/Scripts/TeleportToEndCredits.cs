using UnityEngine;
using UnityEngine.SceneManagement; // Needed for loading scenes

public class TeleportToEndCredits : MonoBehaviour
{
    public Transform player; // The player's transform
    public float teleportRange = 5f; // The range in which the player can teleport

    void Update()
    {
        // Check the distance between the player and the teleport trigger GameObject
        float distance = Vector3.Distance(player.position, transform.position);

        // If the player is within the teleport range
        if (distance <= teleportRange)
        {
            TeleportPlayerToEndCredits();
        }
    }

    void TeleportPlayerToEndCredits()
    {
        // Load the "endcredits" scene
        SceneManager.LoadScene("endcredits");
    }
}
