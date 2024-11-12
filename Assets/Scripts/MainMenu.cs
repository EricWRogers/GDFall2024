using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Kyle Scene");
    }

    
    public void Quitgame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();
    }
}
