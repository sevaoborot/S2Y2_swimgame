using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelID : MonoBehaviour
{
    public void SetLevelID_func(int value)
    {
        LevelConfigManager.ChosenScene = value + 1;
    }
}
