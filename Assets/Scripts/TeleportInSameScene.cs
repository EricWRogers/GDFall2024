using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInSameScene : MonoBehaviour
{
    public Transform teleportDestination;
    public string playerTag = "Player";
    public AudioClip teleportSound;
    public float delay = 2f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            // Start the teleportation coroutine
            StartCoroutine(TeleportWithDelay(other.transform));
        }
    }
    private IEnumerator TeleportWithDelay(Transform player)
    {
        // Wait for the specified delay before teleporting
        yield return new WaitForSeconds(delay);

        // Teleport the player to the destination
        player.position = teleportDestination.position;

        // Play teleport sound if available
        if (audioSource != null && teleportSound != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }
    }
}
