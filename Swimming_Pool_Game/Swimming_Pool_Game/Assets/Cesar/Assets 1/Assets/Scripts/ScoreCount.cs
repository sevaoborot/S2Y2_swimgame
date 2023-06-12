using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreCount : MonoBehaviour
{
    public static int gscore = 0;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + gscore.ToString());

        if (gscore == 4)
        {
            // Your code for when the score reaches 4
        }
    }
}

