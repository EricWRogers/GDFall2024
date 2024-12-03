using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Diologue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int index = 0;
    public float dialogueSpeed;
    public bool writing;
    public Interact other;

    void OnEnable()
    {
        Debug.Log("Enable"+index);
        index = 0;
        StopAllCoroutines();
        NextSentence();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!writing && index == sentences.Length)
            {
                Debug.Log("shutdown dialogue");
                writing = false;
                dialogueText.text = "";
                index = 0;
                StopAllCoroutines();
                transform.parent.gameObject.SetActive(false);
                other.EndDialogue();
                return;
            }

            Debug.Log("Update");
            NextSentence();
        }
    }


    void NextSentence()
    {
        if (!writing)
        {
            if (index <= sentences.Length - 1)
            {
                dialogueText.text = "";
                writing = true;
                StartCoroutine(WriteSentence());
            }
        }
    }


    IEnumerator WriteSentence()
    {
        // Debug.Log("writing");
        
        foreach(char Character in sentences[index].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);

        }
        index++;
        writing = false;
    }

}