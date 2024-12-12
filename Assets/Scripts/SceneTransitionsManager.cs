using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFadeInManager : MonoBehaviour
{
    public Animator transitionAnimator;
    public float fadeInDelay = 0.5f;     
    public string targetSceneName = "BasementLevel";

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene matches the target scene name
        if (scene.name == targetSceneName)
        {
            // Start the fade-in animation only for the target scene
            StartCoroutine(FadeInAfterLoad());
        }
    }

    private IEnumerator FadeInAfterLoad()
    {
        
        yield return new WaitForSeconds(fadeInDelay);

        // Trigger the FadeIn animation on the animator
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("FadeIn"); 
        }
    }
}
