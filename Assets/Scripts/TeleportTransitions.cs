using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportTransitions : MonoBehaviour
{
    public Animator transitionAnimator;  
    public string fadeOutTrigger = "Crossfade_"; 
    public string fadeInTrigger = "Crossfade_start"; 
    public float fadeDuration = 1f; 

    private void Start()
    {
        
        if (transitionAnimator == null)
        {
            Debug.LogError("Animator not assigned to TeleportAnimationTrigger.");
        }
    }

    
    public void TriggerTeleportAnimation(System.Action onTeleportComplete)
    {
        
        TriggerFadeOutAnimation();

        
        StartCoroutine(WaitAndTeleport(onTeleportComplete));
    }

    
    private void TriggerFadeOutAnimation()
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger(fadeOutTrigger);  
        }
    }

    
    private IEnumerator WaitAndTeleport(System.Action onTeleportComplete)
    {
        
        yield return new WaitForSeconds(fadeDuration);

        
        onTeleportComplete?.Invoke();  

        
        yield return new WaitForSeconds(0.2f); 

        
        TriggerFadeInAnimation();
    }

    
    private void TriggerFadeInAnimation()
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger(fadeInTrigger); 
        }
    }
}
