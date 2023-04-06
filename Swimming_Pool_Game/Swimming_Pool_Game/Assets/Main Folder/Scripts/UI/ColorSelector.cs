using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorSelector : MonoBehaviour
{
    public UnityEvent<string> ChosenColorEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChosenColor(string colorName)
    {
        ChosenColorEvent.Invoke(colorName);
    }
}
