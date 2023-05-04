using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnDetector : MonoBehaviour
{
    [SerializeField] string ChosenTypeOfMovement;

    private void Start()
    {
       
    }

    private void SendMovementType()
    {
        gameObject.GetComponentInChildren<MovementSystem>().SetMovementType(ChosenTypeOfMovement);
    }
}
