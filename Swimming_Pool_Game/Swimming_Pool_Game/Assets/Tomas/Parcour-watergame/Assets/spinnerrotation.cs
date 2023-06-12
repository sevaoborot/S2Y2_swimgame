using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnerrotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 360f * Time.deltaTime, 0);
    }
}
