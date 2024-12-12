using UnityEngine;
using System.Collections;
using UnityEngine.UI;  

public class TeleportTransitions : MonoBehaviour
{
    public Image fadeImage;  
    public float fadeOutDuration = 1f;  
    public float fadeInDuration = 1f;  
    public float fadeLingerDuration = 2f;   

    void Start()
    {
        
        Color startColor = fadeImage.color;
        startColor.a = 0f;  
        fadeImage.color = startColor;
    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        FadeOut();  

        
        Invoke("LingerAndFadeIn", fadeLingerDuration);  
    }

    
    private void LingerAndFadeIn()
    {
        FadeIn();  
    }

    
    public void FadeIn()
    {
        StartCoroutine(FadeTo(0f, fadeInDuration)); 
    }

   
    public void FadeOut()
    {
        StartCoroutine(FadeTo(1f, fadeOutDuration)); 
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
      
        float startAlpha = fadeImage.color.a;
        float elapsedTime = 0f;

        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            Color newColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            fadeImage.color = newColor;
            yield return null;
        }

        
        Color finalColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, targetAlpha);
        fadeImage.color = finalColor;
    }
}
