using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private GameObject player;
    private KeyPickup playerKeyPickup;
    public Animator transition;
    public float transitionTime = 1f;
    public string BasementLevel;
    public float interactionDistance = 3f;

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

    void Update()
    {
        if (player != null && playerKeyPickup != null)
        {
            
            if (Vector3.Distance(player.transform.position, transform.position) < interactionDistance)
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (playerKeyPickup.hasKey)
                    {
                        Debug.Log("Player has the key! Loading the scene...");
                        StartCoroutine(LoadLevel());
                    }
                    else
                    {
                        Debug.Log("You need the key to open this door.");
                    }
                }
            }
        }
    }

    private IEnumerator LoadLevel()
    {
        if (transition != null)
        {
            if (!string.IsNullOrEmpty(BasementLevel))
            {
                // Trigger the transition animation
                transition.SetTrigger("Start");
                yield return new WaitForSeconds(transitionTime);

                // Load the new scene after the animation finishes
                SceneManager.LoadScene(BasementLevel);
            }
            else
            {
                Debug.LogWarning("Scene name is empty or invalid.");
            }
        }
        else
        {
            Debug.LogWarning("Transition Animator not assigned!");
        }
    }
}
