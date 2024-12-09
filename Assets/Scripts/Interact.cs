using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public string scene;
    public GameObject button;
    public GameObject dialogueBox;
    public GameObject intheway;
    public GameObject collectable;
    public GameObject pointCounter;


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
        if (button.tag == "Quit")
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        if (button.tag == "Intheway")
        {
            Debug.Log("Intheway");
             intheway.SetActive(false);
             collectable.SetActive(true);
        }
        if (button.tag == "Collectable")
        {
            collectable.SetActive(false);
            

        }
    }

    public void EndDialogue()
    {
        //dialogueBox.SetActive(false);
    }
}
