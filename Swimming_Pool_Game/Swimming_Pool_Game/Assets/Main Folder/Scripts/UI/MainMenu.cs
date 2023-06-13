using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PLayButton()
    {
        SceneManager.LoadScene("Minigames");
    }
    
    public void BackButton()
    {
        SceneManager.LoadScene("main menu");
    }

    public void MiniGame1Button()
    {
        SceneManager.LoadScene("Grid Scene");
    }

    public void MiniGame2Button()
    {
        SceneManager.LoadScene("play1");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
