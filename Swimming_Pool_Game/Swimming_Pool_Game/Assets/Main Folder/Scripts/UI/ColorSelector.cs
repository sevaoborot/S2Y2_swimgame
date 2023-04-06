using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorSelector : MonoBehaviour
{
    public UnityEvent<string> ChosenColorEvent;
    public List<string> SelectedColors = new List<string>();

    public void ChosenColor(string colorName)
    {
        ChosenColorEvent.Invoke(colorName);
        SelectedColors.Add(colorName);
    }
}
