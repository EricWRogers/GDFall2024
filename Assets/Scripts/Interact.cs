using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public string scene;
    public GameObject button;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown() 
    { 
        Debug.Log("Sprite Clicked");
        if (button.tag == "Clue")
        {
            dialogueBox.SetActive(true);
        }
        if (button.tag == "Move")
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
