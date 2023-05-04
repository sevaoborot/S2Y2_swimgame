using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelConfigManager
{
    static public void SetScene()
    {
        SceneManager.LoadScene(Random.Range(1,SceneManager.sceneCountInBuildSettings)); //0 is for main menu
    } 
}
