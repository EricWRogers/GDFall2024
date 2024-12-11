using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitionsManager : MonoBehaviour
{
    public Animator transitionAnimator; 
    public float fadeInDelay = 0.5f;     

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
        
        if (scene.name == "BasementLevel")  
        {
            StartCoroutine(FadeInAfterLoad());
        }
    }

    
    private IEnumerator FadeInAfterLoad()
    {
        
        yield return new WaitForSeconds(fadeInDelay);

        // Trigger the fade-in animation
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("FadeIn");
        }
    }
}
