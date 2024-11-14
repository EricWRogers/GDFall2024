using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject clue;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown() 
    { 
        Debug.Log("Sprite Clicked");
        if (clue.tag == "Interactable")
        {
            dialogueBox.SetActive(true);
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
