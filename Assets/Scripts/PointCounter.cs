using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCounter : MonoBehaviour
{

    public int points;
    public string scene;

    // Update is called once per frame
    void Update()
    {
        if (points == 3)
        {
            SceneManager.LoadScene(scene);
        }
    }
    void OnMouseDown() 
    { 
        Debug.Log("Sprite Clicked");
        {
            points += 1;
        }
    }
}