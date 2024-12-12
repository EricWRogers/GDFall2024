using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private GameObject player;
    private KeyPickup playerKeyPickup;  
    public Animator transition;
    public float transitionTime = 1f;
    public string Level;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            
            playerKeyPickup = player.GetComponent<KeyPickup>();
        }
        else
        {
            Debug.LogWarning("Player object with 'Player' tag is not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Player entered trigger, hasKey: " + (playerKeyPickup != null ? playerKeyPickup.hasKey.ToString() : "null"));

            if (playerKeyPickup != null && playerKeyPickup.hasKey)
            {
                // If the player has the key, start the scene transition
                Debug.Log("Player has the key! Starting the scene transition...");
                StartCoroutine(LoadLevel());
            }
            else
            {
                
                Debug.Log("You need the key to open this door.");
            }
        }
    }

    private IEnumerator LoadLevel()
    {
        // Check if transition is assigned and the player has the key
        if (transition != null && playerKeyPickup != null && playerKeyPickup.hasKey)
        {
            
            transition.SetTrigger("Start");

            
            yield return new WaitForSeconds(transitionTime);

            if (!string.IsNullOrEmpty(Level))
            {
                AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(Level);

                
                while (!sceneLoad.isDone)
                {
                    yield return null;
                }
            }
            else
            {
                Debug.LogWarning("Scene name is empty or invalid.");
            }
        }
        else
        {
            Debug.LogWarning("Transition Animator not assigned or player doesn't have the key.");
        }
    }
}
