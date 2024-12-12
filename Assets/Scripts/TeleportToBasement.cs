using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToBasement : MonoBehaviour
{
    public Transform teleportDestination;
    public string playerTag = "Player";
    public AudioClip teleportSound;
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            if (audioSource != null && teleportSound != null)
            {
                audioSource.PlayOneShot(teleportSound);
            }

            if (transitionAnimator != null)
            {
                StartCoroutine(FadeOutAndLoadScene("BasementLevel2"));
            }
        }
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // Trigger fade-out transition
        transitionAnimator.SetTrigger("Start");

        // Wait for the fade-out animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Load the new scene asynchronously
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);

        // Ensure the scene is fully loaded before proceeding
        while (!sceneLoad.isDone)
        {
            yield return null;
        }

        // Trigger fade-in animation after the scene is loaded
        StartCoroutine(PlayFadeInAfterLoad());
    }

    private IEnumerator PlayFadeInAfterLoad()
    {
        // Wait a bit after the scene is loaded to ensure it's ready to show
        yield return new WaitForSeconds(0.2f);

        // Trigger fade-in animation
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("FadeIn");
        }
    }
}
