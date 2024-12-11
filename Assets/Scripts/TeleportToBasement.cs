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
                StartCoroutine(FadeOutAndLoadScene("BasementLevel"));
            }
        }
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        
        transitionAnimator.SetTrigger("Start");

        
        yield return new WaitForSeconds(transitionTime);

        
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);

        
        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }
}
