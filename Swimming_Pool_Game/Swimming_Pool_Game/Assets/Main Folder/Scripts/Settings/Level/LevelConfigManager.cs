using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelConfigManager
{
    static public bool isRandomised = false;
    static public int ChosenScene = 2;

    static public void SetScene()
    {
        if (isRandomised) SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings)); //0 is for main menu
        else SceneManager.LoadScene(ChosenScene);
    }
}