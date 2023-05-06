using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLevelRandomize : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;

    public void SetLevelRandomize_func()
    {
        if (LevelConfigManager.isRandomised) {
            LevelConfigManager.isRandomised = false;
            buttonText.SetText("Level random is off");
        }
        else {
            LevelConfigManager.isRandomised = true;
            buttonText.SetText("Level random is on");
        }
    }
}
