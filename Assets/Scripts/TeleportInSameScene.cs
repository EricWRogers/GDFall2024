using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInSameScene : MonoBehaviour
{
    public Transform teleportDestination;
    public string playerTag = "Player";
    public AudioClip teleportSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            other.transform.position = teleportDestination.position;
        }

        if (audioSource != null && teleportSound != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }
    }
}
