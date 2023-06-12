using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the trigger has the ScoreCount script attached
        ScoreCount scoreCount = other.GetComponent<ScoreCount>();
        if (scoreCount != null)
        {
            // Increase the score by 1
            ScoreCount.gscore++;
        }
    }
}